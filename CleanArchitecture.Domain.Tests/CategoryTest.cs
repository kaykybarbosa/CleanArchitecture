using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Validation;
using FluentAssertions;

namespace CleanArchitecture.Domain.Tests
{
    public class CategoryTest
    {
        [Fact]
        public void CreateCategory_WithValidParameters_ReturnObjectValidState()
        {
            //Arrange
            int id = 1;
            string name = "Category Name";

            //Act
            Action action = () => new Category(id, name);

            //Assert
            action.Should().NotThrow<DomainExceptionValidation>();
        }
        
        [Fact]
        public void CreateCategory_NagativeIdValue_ReturnDomainExceptionValidation()
        {
            //Arrange
            int id = -1;
            string name = "Category Name";

            //Act
            Action action = () => new Category(id, name);

            //Assert
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid id value.");
        }   
        
        [Fact]
        public void CreateCategory_WithNullNameValue_ReturnDomainExceptionValidation()
        {
            //Arrange
            int id = 1;
            string? name = null;

            //Act
            Action action = () => new Category(id, name);

            //Assert
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name. Name is required.");
        }
           
        [Fact]
        public void CreateCategory_MissingNameValue_ReturnDomainExceptionValidation()
        {
            //Arrange
            int id = 1;
            string name = "";

            //Act
            Action action = () => new Category(id, name);

            //Assert
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name. Name is required.");
        }
        
        [Fact]
        public void CreateCategory_ShortNameValue_ReturnDomainExceptionValidation()
        {
            //Arrange
            int id = 1;
            string name = "Ca";

            //Act
            Action action = () => new Category(id, name);

            //Assert
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name. Too short, minimum 3 characters.");
        }
    }
}