-- Dropping tables if they exist
DROP TABLE IF EXISTS ProductDetails;
DROP TABLE IF EXISTS Products;
DROP TABLE IF EXISTS ProductBrand;
DROP TABLE IF EXISTS PersonCategory;
DROP TABLE IF EXISTS ProductCategory;

-- Creating ProductCategory Table
CREATE TABLE ProductCategory (
    ProductCategoryId INT PRIMARY KEY NOT NULL IDENTITY,
    ProductCategoryName NVARCHAR(50) NOT NULL
);

-- Creating PersonCategory Table
CREATE TABLE PersonCategory (
    PersonCategoryId INT PRIMARY KEY NOT NULL IDENTITY,
    PersonCategoryName NVARCHAR(50) NOT NULL
);

-- Creating ProductBrand Table
CREATE TABLE ProductBrand (
    ProductBrandId INT PRIMARY KEY NOT NULL IDENTITY,
    BrandName NVARCHAR(50) NOT NULL
);

-- Creating Products Table
CREATE TABLE Products (
    ProductId INT PRIMARY KEY NOT NULL IDENTITY,
    PersonCategoryId INT NOT NULL,
    ProductCategoryId INT NOT NULL,
    ProductBrandId INT NOT NULL,
    BrandArticleNumber NVARCHAR(50) NOT NULL,
    FOREIGN KEY (PersonCategoryId) REFERENCES PersonCategory(PersonCategoryId),
    FOREIGN KEY (ProductCategoryId) REFERENCES ProductCategory(ProductCategoryId),
    FOREIGN KEY (ProductBrandId) REFERENCES ProductBrand(ProductBrandId)
);

-- Creating ProductDetails Table
CREATE TABLE ProductDetails (
    ProductId INT PRIMARY KEY NOT NULL,
    Title NVARCHAR(200) NOT NULL,
    Description NVARCHAR(MAX),
    Size NVARCHAR(20),
    Color NVARCHAR(20),
    InStock BIT,
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
);
