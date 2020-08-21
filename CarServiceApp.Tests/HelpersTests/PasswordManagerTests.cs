using CarServiceApp.Helpers;
using System;
using Xunit;

namespace CarServiceApp.Tests.HelpersTests
{
    public class PasswordManagerTests
    {
        [Fact]
        public void GetPassHashNotEmptyParams()
        {
            // Arrange
            string login = "login123";
            string password = "password321";
            string expectedHash = "84dd4c6206a42dbd6fe75ba2c5920cfe";

            // Act
            string actualHash = PasswordManager.GetPassHash(login, password);

            // Assert
            Assert.NotNull(actualHash);
            Assert.Equal(expectedHash, actualHash);
        }

        [Fact]
        public void GetPassHashNullParams()
        {
            // Arrange
            string login = null;
            string password = null;

            // Act
            Action actual = () => PasswordManager.GetPassHash(login, password);

            // Assert
            Assert.Throws<Exception>(actual);
        }

        [Fact]
        public void GetPassHashEmptyParams()
        {
            // Arrange
            string login = string.Empty;
            string password = string.Empty;

            // Act
            Action actual = () => PasswordManager.GetPassHash(login, password);

            // Assert
            Assert.Throws<Exception>(actual);
        }

        [Fact]
        public void GetPassHashCaseSensetive()
        {
            // Arrange
            string login = "login123";
            string password = "password321";

            // Act
            string hashUpper = PasswordManager.GetPassHash(login.ToUpper(), password.ToUpper());
            string hashLower = PasswordManager.GetPassHash(login.ToLower(), password.ToLower());

            // Assert
            Assert.NotEqual("", hashUpper);
            Assert.NotEqual("", hashLower);
            Assert.NotEqual(hashUpper, hashLower);
        }
    }
}
