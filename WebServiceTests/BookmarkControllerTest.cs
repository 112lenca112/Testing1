using System;
using AutoMapper;
using DataServiceLib;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

using WebService.Controller;
using WebService.Model;

using Xunit;

namespace WebServiceTests
{
    public class BookmarkControllerTest
    {
        private Mock<IDataService> _dataServiceMock;
        private Mock<IMapper> _mapperMock;
        private Mock<IUrlHelper> _urlMock;

        public BookmarkControllerTest()
        {
             _dataServiceMock = new Mock<IDataService>();
             _mapperMock = new Mock<IDataService>();
             _urlMock = new Mock<IUrlHelper>();
        }


        [Fact]
        public void GetBookmartkWithValidIdSouldReturnOk()
        {
            
            _dataServiceMock.Setup(x => x.GetBookMark(1).Returns(new BookMark {BookmarkPerson = new BookmarkPerson()}));

            
            _mapperMock.Setup(x => x.Map<BookmarkPersonDto>(It.IsAny<BookMark>())).Returns(new BookmarkPersonDto());

            

            var ctrl = new BookmarkController(_dataServiceMock.Object, _mapperMock.Object);
            ctrl.Url = _urlMock.Object;

            var response = ctrl.GetBookMark(1);

            response.Should().BeOfType<OkObjectResult>(); 

        }


        [Fact]
        public void GetBookmartkWithInvalidIdSouldReturnNotFound()
        {

            var ctrl = new BookmarkController(_dataServiceMock.Object, null);

            var response = ctrl.GetBookMark(10);

            response.Should().BeOfType<NotFoundResult>();

        }

    }
}
