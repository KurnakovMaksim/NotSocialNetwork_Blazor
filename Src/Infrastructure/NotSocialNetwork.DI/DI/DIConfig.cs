﻿using Microsoft.Extensions.DependencyInjection;
using NotSocialNetwork.Application.Entities;
using NotSocialNetwork.Application.Interfaces.Facades;
using NotSocialNetwork.Application.Interfaces.Repositories;
using NotSocialNetwork.Application.Interfaces.Systems;
using NotSocialNetwork.Application.Interfaces.UseCases.Publication;
using NotSocialNetwork.Application.Interfaces.UseCases.User;
using NotSocialNetwork.Application.UseCases.Publication;
using NotSocialNetwork.Application.UseCases.User;
using NotSocialNetwork.Data.EFRepositories;
using NotSocialNetwork.Services.Facades;
using NotSocialNetwork.Services.Systems;

namespace NotSocialNetwork.DI.DIConfig
{
    public static class DIConfig
    {
        public static void ConfigureDI(this IServiceCollection services)
        {
            ConfigureRepositories(services);
            ConfigureUseCases(services);
            ConfigureSystems(services);
            ConfigureFacades(services);
        }

        private static void ConfigureRepositories(IServiceCollection services)
        {
            services.AddTransient<IRepositoryAsync<UserEntity>, EFCoreRepository<UserEntity>>();
            services.AddTransient<IRepositoryAsync<PublicationEntity>, EFCoreRepository<PublicationEntity>>();
            services.AddTransient<IRepositoryAsync<ImageEntity>, EFCoreRepository<ImageEntity>>();
        }

        private static void ConfigureUseCases(IServiceCollection services)
        {
            ConfigureUseCasesUser(services);
            ConfigureUseCasesPublication(services);
        }

        private static void ConfigureUseCasesUser(IServiceCollection services)
        {
            services.AddTransient<IAddableUserAsync, AddUser>();
            services.AddTransient<IEditableUserAsync, EditUser>();
            services.AddTransient<IGetableUser, GetUser>();
        }

        private static void ConfigureUseCasesPublication(IServiceCollection services)
        {
            services.AddTransient<IAddablePublicationAsync, AddPublication>();
            services.AddTransient<IEditablePublicationAsync, EditPublication>();
            services.AddTransient<IGetablePublication, GetPublication>();
        }

        private static void ConfigureSystems(IServiceCollection services)
        {
            services.AddTransient<IImageFileSystemAsync, ImageFileSystem>();
            services.AddTransient<IImageRepositorySystemAsync, ImageRepositorySystem>();
            services.AddTransient<IJwtSystem, JwtSystem>();
        }

        private static void ConfigureFacades(IServiceCollection services)
        {
            services.AddTransient<IFileFacadeAsync<ImageEntity>, ImageFacade>();
        }
    }
}
