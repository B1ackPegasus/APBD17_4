using NuGet.Frameworks;

namespace LegacyApp.Tests;

public class UserServiceTests
{
    [Fact]
    public void AddUserReturnFalseWhenFirstNameIsEmpty()
    {
        //Arrange 
        var userService = new UserService();
        
        //Act 
        var result = userService.AddUser(null,
            "Smith",
            "smithpage@gmail.pl",
            DateTime.Parse("2000-01-01"), 3);
        
        //Assert
        Assert.False(result);
    }
    [Fact]
    public void AddUserThrowsExceptionWhenClientDoesNotExist()
    {
        //Arrange 
        var userService = new UserService();
        
        //Act 
        Action act =()=> userService.AddUser("John",
            "Smith",
            "smithpage@gmail.pl",
            DateTime.Parse("2000-01-01"), 100);
        
        //Assert
        Assert.Throws<ArgumentException>(act);
    }

    [Fact]
    public void AddUser_ReturnsFalseWhenMissingAtSignAndDotInEmail()
    {
        var userService = new UserService();
        var result = userService.AddUser("Jany",
            "Smith",
            "smithpagegmailpl",
            DateTime.Parse("2000-01-01"), 3);
        
        //Assert
        Assert.False(result);
        
    }
[Fact]
    public void AddUser_ReturnsFalseWhenYoungerThen21YearsOld()
    {
        var userService = new UserService();
         var resultAge= userService.AddUser("Adam",
             "Kwiatkowski",
             "kwiatkowski@wp.pl",
             DateTime.Parse("2007-01-01"), 5);
        
         //Assert
         Assert.False(resultAge);
    }
    [Fact]
    public void AddUser_ReturnsTrueWhenVeryImportantClient()
    {
        var userService = new UserService();
        var resultImportantCl= userService.AddUser("Adam",
            "Malewski",
            "malewski@gmail.pl",
            DateTime.Parse("2000-01-01"), 2);
        
        //Assert
        Assert.True(resultImportantCl);
    }
    [Fact]
    public void AddUser_ReturnsTrueWhenImportantClient()
    {
        var userService = new UserService();
        var resultImportantCl= userService.AddUser("Adam",
            "Doe",
            "doe@gmail.pl",
            DateTime.Parse("2000-01-01"), 4);
        
        //Assert
        Assert.True(resultImportantCl);
    }
    [Fact]
    public void AddUser_ReturnsTrueWhenNormalClient()
    {
        var userService = new UserService();
        var resultNormalCli= userService.AddUser("Andrzej",
            "Kwiatkowski",
            "kwiatkowski@wp.pl",
            DateTime.Parse("1990-01-01"), 5);
        
        //Assert
        Assert.True(resultNormalCli);
    }
    [Fact]
    public void AddUser_ReturnsFalseWhenNormalClientWithNoCreditLimit()
    {
        var userService = new UserService();
        var result= userService.AddUser("John",
            "Kowalski",
            "kowalski@wp.pl",
            DateTime.Parse("1990-01-01"), 1);
        
        //Assert
        Assert.False(result);
    }
    [Fact]
    public void AddUser_ThrowsExceptionWhenUserDoesNotExist()
    {
        var userService = new UserService();

        //Act 
        Action act =()=> userService.AddUser("Andrzej",
            "Limanoswski",
            "limanowski@wp.pl",
            DateTime.Parse("2000-01-01"), 3);
        
        //Assert
        Assert.Throws<ArgumentException>(act);
    }
    [Fact]
    public void AddUser_ThrowsExceptionWhenUserNoCreditLimitExistsForUser()
    {
        var userService = new UserService();
        Action act =()=> userService.AddUser("Andrzej",
            "Andrzejewicz",
            "adrzejewicz@wp.pl",
            DateTime.Parse("2000-01-01"), 6);
        
        //Assert
        Assert.Throws<ArgumentException>(act);
    }
    
   
     
    
}