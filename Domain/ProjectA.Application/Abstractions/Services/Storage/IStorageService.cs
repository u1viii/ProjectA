﻿namespace ProjectA.Application.Abstractions.Services.Storage
{
    public interface IStorageService:IStorage
    {
        public string StorageName { get; }
    }
}
