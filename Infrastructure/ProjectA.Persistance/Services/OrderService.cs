using Microsoft.EntityFrameworkCore;
using ProjectA.Application.Abstractions.Services;
using ProjectA.Application.Abstractions.Services.Storage;
using ProjectA.Application.DTOs.Orders;
using ProjectA.Application.Exceptions.CategoryExceptions;
using ProjectA.Application.Exceptions.CommonExceptions;
using ProjectA.Application.Exceptions.OrderExceptions;
using ProjectA.Application.Repositories;
using ProjectA.Core.Entities;
using ProjectA.Persistance.Repositories;
using System.Collections.ObjectModel;

namespace ProjectA.Persistance.Services
{
    public class OrderService : IOrderService
    {

        IOrderWriteRepository _orderWrite { get; }
        IOrderReadRepository _orderRead { get; }
        ICategoryReadRepository _categoryRead { get; }
        IStorageService _storageService { get; }
        IProjectFileWriteRepository _projectFileWriteRepo { get; }
        IProjectFileReadRepository _projectFileReadRepo { get; }
        IOrderFileReadRepository _orderFileReadRepo { get; }

        public OrderService(IOrderWriteRepository orderWrite, IOrderReadRepository orderRead, ICategoryReadRepository categoryRead, IStorageService storageService, IProjectFileWriteRepository projectFileWriteRepo, IProjectFileReadRepository projectFileReadRepo, IOrderFileReadRepository orderFileReadRepo)
        {
            _orderWrite = orderWrite;
            _orderRead = orderRead;
            _categoryRead = categoryRead;
            _storageService = storageService;
            _projectFileWriteRepo = projectFileWriteRepo;
            _projectFileReadRepo = projectFileReadRepo;
            _orderFileReadRepo = orderFileReadRepo;
        }
        public async Task CreateAsync(DTO_OrderCreate orderCreate)
        {
            Order order = new Order
            {
                DeadLine = orderCreate.DeadLine,
                Name = orderCreate.Name,
                Quantity = orderCreate.Quantity,
                Unit = orderCreate.Unit,
                Color = orderCreate.Color,
                Manufacturer = orderCreate.Manufacturer,
                Note = orderCreate.Note,
                PaymentId = orderCreate.PaymentId
            };
            ICollection<OrderCategory> orderCategories = new Collection<OrderCategory>();
            foreach (var catId in orderCreate.CategoryIds)
            {
                if (await _categoryRead.Table.AnyAsync(c => c.Id == catId))
                {
                    orderCategories.Add(new OrderCategory { CategoryId = catId, Order = order });
                }
                else
                {
                    throw new CategoryNotFoundException();
                }
            }
            if (orderCreate.Pictures != null)
            {
                string path = Path.Combine("assets", "imgs", "order");
                List<(string fileName, string filePath)> imageResults = await _storageService.UploadAsync(path, orderCreate.Pictures);
                Collection<OrderImageFile> files = new Collection<OrderImageFile>();
                foreach (var item in imageResults)
                {
                    files.Add(new OrderImageFile { Path = item.filePath, Name = item.fileName, Order = order, Storage = _storageService.StorageName });
                }
                order.OrderImageFiles = files;
            }
            if (orderCreate.Documents != null)
            {
                string path = Path.Combine("assets", "documents", "order");
                List<(string fileName, string filePath)> fileResults = await _storageService.UploadAsync(path, orderCreate.Documents);
                Collection<OrderDocumentFile> files = new Collection<OrderDocumentFile>();
                foreach (var result in fileResults)
                {
                    files.Add(new() { Name = result.fileName, Path = result.filePath, Order = order, Storage = _storageService.StorageName });
                }
                order.OrderDocumentFiles = files;
            }
            order.OrderCategories = orderCategories;
            await _orderWrite.AddAsync(order);
            await _orderWrite.SaveChangesAsync();
        }

        public async Task UpdateAsync(DTO_OrderUpdate orderUpdate)
        {
            if (orderUpdate.Id == null) throw new BadRequestException();
            Order order = await _orderRead.GetSingleAsync(o => o.Id == orderUpdate.Id,true);
            if (order == null) throw new OrderNotFoundException();
            Collection<OrderCategory> existCategories = new();
            if (orderUpdate.CategoryIds == null) throw new BadRequestException();
            foreach (var catId in orderUpdate.CategoryIds)
            {
                if (await _categoryRead.Table.AnyAsync(c => c.Id == catId))
                {
                    existCategories.Add(new OrderCategory { CategoryId = catId, OrderId = order.Id });
                }
                else
                {
                    throw new CategoryNotFoundException();
                }
            }
            foreach (var item in (orderUpdate.DeletedFileIds ?? new Collection<Guid>()))
            {
                if (await _projectFileReadRepo.Table.AnyAsync(f=>f.Id == item))
                {
                    var file = await _projectFileReadRepo.GetByIdAsync(item.ToString());
                    bool b = _storageService.DeleteFile(Path.Combine(file.Path, file.Name));
                    _projectFileWriteRepo.Remove(item.ToString());
                }
                else
                {
                    throw new FileNotFoundException();
                }
            }
            if (orderUpdate.Pictures != null)
            {
                string path = Path.Combine("assets", "imgs", "order");
                List<(string fileName, string filePath)> imageResults = await _storageService.UploadAsync(path, orderUpdate.Pictures);
                Collection<OrderImageFile> files = new Collection<OrderImageFile>();
                foreach (var item in imageResults)
                {
                    files.Add(new OrderImageFile { Path = item.filePath, Name = item.fileName, OrderId = order.Id, Storage = _storageService.StorageName });
                }
                order.OrderImageFiles = files;
            }
            if (orderUpdate.Documents != null)
            {
                string path = Path.Combine("assets", "documents", "order");
                List<(string fileName, string filePath)> fileResults = await _storageService.UploadAsync(path, orderUpdate.Documents);
                Collection<OrderDocumentFile> files = new Collection<OrderDocumentFile>();
                foreach (var result in fileResults)
                {
                    files.Add(new() { Name = result.fileName, Path = result.filePath, OrderId = order.Id, Storage = _storageService.StorageName });
                }
                order.OrderDocumentFiles = files;
            }
            order.OrderCategories = existCategories;
            order.Name = orderUpdate.Name;
            order.DeadLine = orderUpdate.DeadLine;
            order.Quantity = orderUpdate.Quantity;
            order.Unit = orderUpdate.Unit ?? order.Unit;
            order.Color = orderUpdate.Color ?? order.Color;
            order.Manufacturer = orderUpdate.Manufacturer;
            order.Note = orderUpdate.Note;
            order.PaymentId = orderUpdate.PaymentId;
            await _orderWrite.SaveChangesAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            Order order = await _orderRead.GetByIdAsync(id.ToString());
            if (order == null) throw new OrderNotFoundException();
            //var files = _orderFileReadRepo.GetWhere(f=>f.OrderId == id);
            //if (files != null)
            //{
            //    foreach (var item in files)
            //    {
            //        _storageService.DeleteFile(Path.Combine(item.Path,item.Name));
            //        _projectFileWriteRepo.Remove(item);
            //    }
            //}
            _orderWrite.Remove(order);
            await _orderWrite.SaveChangesAsync();
        }
    }
}
