﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NotSocialNetwork.API.Endpoints.Publication.Get;
using NotSocialNetwork.Application.Entities;
using NotSocialNetwork.Application.Exceptions;
using NotSocialNetwork.Application.Interfaces.UseCases.Publication;
using System;
using Xunit;

namespace NotSocialNetwork.Presentation.Tests.UnitTests.API.Endpoints.Publication.Get.Unsuccesses
{
    public class PublicationControllerUnsuccessTest
    {
        private readonly PublicationEntity _publication = new PublicationEntity()
        {
            Author = new UserEntity(),
        };

        [Fact]
        public void Get_GetPublicationsIfPublicationsNoMore_NotFound404()
        {
            // Arrange
            var getPublication = new Mock<IGetablePublication>();
            var mapper = new Mock<IMapper>();

            var publicationController = new PublicationController(
                                        getPublication.Object,
                                        mapper.Object);
            var validIndex = 0;

            getPublication.Setup(gp => gp.GetByPagination(validIndex))
                              .Throws(new ObjectNotFoundException("No more publications."));

            // Act
            var result = publicationController.Get(validIndex);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result.Result);
        }

        [Fact]
        public void Get_GetPublicationsIfIndexInvalid_BadRequest400()
        {
            // Arrange
            var getPublication = new Mock<IGetablePublication>();
            var mapper = new Mock<IMapper>();

            var publicationController = new PublicationController(
                                        getPublication.Object,
                                        mapper.Object);
            var invalidIndex = -1;

            getPublication.Setup(gp => gp.GetByPagination(invalidIndex))
                              .Throws(new InvalidOperationException("Invalid index."));

            // Act
            var result = publicationController.Get(invalidIndex);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public void Get_GetByIdIfPublicationNotFound_NotFound404()
        {
            // Arrange
            var getPublication = new Mock<IGetablePublication>();
            var mapper = new Mock<IMapper>();

            var publicationController = new PublicationController(
                                        getPublication.Object,
                                        mapper.Object);

            getPublication.Setup(gp => gp.GetById(_publication.Id))
                              .Throws(new ObjectNotFoundException("Publication not found."));

            // Act
            var result = publicationController.Get(_publication.Id);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result.Result);
        }

        [Fact]
        public void Get_GetByIdIfAuthorDontHavePublications_NotFound404()
        {
            // Arrange
            var getPublication = new Mock<IGetablePublication>();
            var mapper = new Mock<IMapper>();

            var publicationController = new PublicationController(
                                        getPublication.Object,
                                        mapper.Object);

            getPublication.Setup(gp => gp.GetAllByAuthorId(_publication.Author.Id))
                              .Throws(new ObjectNotFoundException("Author dont have a publications."));

            // Act
            var result = publicationController.GetAllByAuthor(_publication.Author.Id);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result.Result);
        }
    }
}
