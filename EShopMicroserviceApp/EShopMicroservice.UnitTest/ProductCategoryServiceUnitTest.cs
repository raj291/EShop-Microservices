using AutoMapper;
using Moq;
using ProductApi.Core.Contracts.Repository;
using ProductApi.Core.Entity;
using ProductApi.Core.Models.Response;
using ProductApi.Helper;
using ProductApi.Infrastructure.Service;

namespace EShopMicroservice.UnitTest;

[TestClass]
public class ProductCategoryServiceUnitTest
{
    private ProductCategoryServiceAsync _sut;
    private Mock<IProductCategoryRepositoryAsync> _mockProductCategoryAsync;
    // [ClassInitialize]
    // public void OneTimeSetup()
    // {
    //     
    // }
    //
    [TestInitialize]
    public void Setup()
    {
        
        var mockMapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new ProductCategoryMapper());
        });
        var mapper = mockMapperConfig.CreateMapper();
        _mockProductCategoryAsync = new Mock<IProductCategoryRepositoryAsync>();
        _sut = new ProductCategoryServiceAsync(_mockProductCategoryAsync.Object, mapper );
        
    }
    [TestMethod]
    public async Task GetAllProductCategories_For_FakeData_Test()
    {
        //productCategoryService.cs == GetallCategoriesAsycn()
        //System Under Test : SUT 
        
        List<ProductCategory> _categories = new List<ProductCategory>
        {
            new ProductCategory { Id = 1, Name = "Book"},
            new ProductCategory { Id = 1, Name = "Electronics"},
            new ProductCategory { Id = 1, Name = "Pets"},
            new ProductCategory { Id = 1, Name = "Juice"}
        };
        
        // _sut = new ProductCategoryServiceAsync(new MockProductCategoryRepository(), mapper );
        
        //Arrange
        _mockProductCategoryAsync.Setup(x => x.GetAllAsync()).ReturnsAsync(_categories);
        //Act (AAA)
        var categories = await _sut.GetAllProductCategoryAsync();
        //Assert(AAA)
        Assert.IsNotNull(categories);
        Assert.IsInstanceOfType(categories,typeof(IEnumerable<ProductCategoryResponseModel>));
        Assert.AreEqual(4, categories.Count());
        
    }

    [TestMethod]
    public async Task TestOfDeleteCategoryReturnsInterger()
    {
        // _mockProductCategoryAsync.Setup(x => x.GetByIdAsync()).ReturnsAsync();
    }
    
}

/**public class MockProductCategoryRepository : IProductCategoryRepositoryAsync
{
    public async Task<int> InsertAsync(ProductCategory entity)
    {
        throw new NotImplementedException();
    }

    public async Task<int> UpdateAsync(ProductCategory entity)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteAysnc(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<ProductCategory> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ProductCategory>> GetAllAsync()
    {
        // Get the Fake Data and not the real data from here.
        var _categories = new List<ProductCategory>
        {
            new ProductCategory { Id = 1, Name = "Book"},
            new ProductCategory { Id = 1, Name = "Electronics"},
            new ProductCategory { Id = 1, Name = "Pets"},
            new ProductCategory { Id = 1, Name = "Juice"}
        };

        return _categories;
    }
}

**/

