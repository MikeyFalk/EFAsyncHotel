using EFAsyncHotel.Models.Interfaces.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace HotelTests
{
    public class UnitTest1m : Mock
    {
        [Fact]
        public async Task CanAddAndDropAHotel()
        {
            //Arrange
            var hotel = await CreateAndSaveTestHotel();

            var repository = new HotelRepository(_db);


            //Act
            await repository.Create(hotel);

            //Assert
            var actualHotel = await repository.GetHotel(hotel.Id);

            Assert.NotNull(actualHotel);

            //Act
            await repository.DeleteHotel(hotel.Id);

            //Assert
            actualHotel = await repository.GetHotel(hotel.Id);
            Assert.Null(actualHotel);


        }

        [Fact]
        public async Task CanAddAndDropAmenity()
        {
            //Arrange
            var amentiy = await CreateAndSaveTestAmenity();

            var repository = new AmenityRepository(_db);

            //Act
            await repository.Create(amentiy);

            //Assert
            var actualAmenity = await repository.GetAmenity(amentiy.Id);

            Assert.NotNull(actualAmenity);

            await repository.DeleteAmenity(amentiy.Id);
            actualAmenity = await repository.GetAmenity(amentiy.Id);
            Assert.Null(actualAmenity);
            

        }

    }
}
