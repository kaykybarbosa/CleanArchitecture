using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Validation;
using FluentAssertions;

namespace CleanArchitecture.Domain.Tests
{
    public class ProductTest
    {
        [Fact]
        public void CreateProduct_WithValidParameters_ReturnObkectValidState()
        {
            //Arrange
            string name = "Name";
            string description = "Description";
            decimal price = 1;
            int stock = 1;
            string image = "Image";

            //Act
            Action action = () => new Product(name, description, price, stock, image);

            //Assert
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_NagativeIdValue_ReturnDomainExceptionValidation()
        {
            //Arrange
            int idInvalid = -1;
            string name = "Name";
            string description = "Description";
            decimal price = 1;
            int stock = 1;
            string image = "Image";

            //Act
            Action action = () => new Product(idInvalid, name, description, price, stock, image);

            //Assert
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid id value.");
        }

        [Fact]
        public void CreateProduct_WithNameNull_ReturnDomainExceptionValidation()
        {
            //Arrange
            string name = null;
            string description = "Description";
            decimal price = 1;
            int stock = 1;
            string image = "Image";

            //Act
            Action action = () => new Product(name, description, price, stock, image);

            //Assert
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name. Name is required.");
        }

        [Fact]
        public void CreateProduct_MissingName_ReturnDomainExceptionValidation()
        {
            //Arrange
            string name = "Na";
            string description = "Description";
            decimal price = 1;
            int stock = 1;
            string image = "Image";

            //Act
            Action action = () => new Product(name, description, price, stock, image);

            //Assert
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name. Too short, minimum 3 characters.");
        }

        [Fact]
        public void CreateProduct_WithDescriptionNull_ReturnDomainExceptionValidation()
        {
            //Arrange
            string name = "Name";
            string description = "";
            decimal price = 1;
            int stock = 1;
            string image = "Image";

            //Act
            Action action = () => new Product(name, description, price, stock, image);

            //Assert
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid description. Description is required.");
        }

        [Fact]
        public void CreateProduct_MissingDescription_ReturnDomainExceptionValidation()
        {
            //Arrange
            string name = "Name";
            string description = "Desc";
            decimal price = 1;
            int stock = 1;
            string image = "Image";

            //Act
            Action action = () => new Product(name, description, price, stock, image);

            //Assert
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid description. Too short, minimum 5 characters.");
        }

        [Fact]
        public void CreateProduct_NegativePriceValue_ReturnDomainExceptionValidation()
        {
            //Arrange
            string name = "Name";
            string description = "Description";
            decimal price = -1;
            int stock = 1;
            string image = "Image";

            //Act
            Action action = () => new Product(name, description, price, stock, image);

            //Assert
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid price value.");
        }

        [Fact]
        public void CreateProduct_NegativeStockValue_ReturnDomainExceptionValidation()
        {
            //Arrange
            string name = "Name";
            string description = "Description";
            decimal price = 1;
            int stock = -1;
            string image = "Image";

            //Act
            Action action = () => new Product(name, description, price, stock, image);

            //Assert
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid stock value.");
        }

        [Fact]
        public void CreateProduct_LongImage_ReturnDomainExceptionValidation()
        {
            //Arrange
            string name = "Name";
            string description = "Description";
            decimal price = 1;
            int stock = 1;
            string image = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean vulputate eleifend tellus. Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim. Aliquam lorem ante, dapibus in, viverra quis, feugiat a, tellus. Phasellus viverra nulla ut metus varius laoreet. Quisque rutrum. Aenean imperdiet. Etiam ultricies nisi vel augue. Curabitur ullamcorper ultricies nisi. Nam eget dui. Etiam rhoncus. Maecenas tempus, tellus eget condimentum rhoncus, sem quam semper libero, sit amet adipiscing sem neque sed ipsum. Nam quam nunc, blandit vel, luctus pulvinar, hendrerit id, lorem. Maecenas nec odio et ante tincidunt tempus. Donec vitae sapien ut libero venenatis faucibus. Nullam quis ante. Etiam sit amet orci eget eros faucibus tincidunt. Duis leo. Sed fringilla mauris sit amet nibh. Donec sodales sagittis magna. Sed consequat, leo eget bibendum sodales, augue velit cursus nunc, quis gravida magna mi a libero. Fusce vulputate eleifend sapien. Vestibulum purus quam, scelerisque ut, mollis sed, nonummy id, metus. Nullam accumsan lorem in dui. Cras ultricies mi eu turpis hendrerit fringilla. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; In ac dui quis mi consectetuer lacinia. Nam pretium turpis"; 

            //Act
            Action action = () => new Product(name, description, price, stock, image);

            //Assert
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid image. Too long, maximum 250 characters.");
        }
    }
}
