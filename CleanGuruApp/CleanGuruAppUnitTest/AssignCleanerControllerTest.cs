using System;
using Xunit;
using CleanGuruApp.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CleanGuruAppUnitTest
{
    public class AssignCleanerControllerTest
    {
        [Fact]
        public void VerifyIndexViewType()
        {
            var controller = new AssignCleanerController();

            var result = controller.Index();

            Assert.IsType<ViewResult>(result);

        }

        [Fact]
        public void VerifyGetDistance()
        {
            //Make sure they google API key is specified in AssignCleanerController, it removed for security. 
            var controller = new AssignCleanerController();

            int result = 17179;

            int actualval = controller.getDistance("1000 bay street", "5336 bathurst street");

            Assert.Equal(actualval, result);

        }


    }
}
