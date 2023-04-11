using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics.Metrics;
using System.IO;
using System.Numerics;
using VetMedPlus.API.Models;
using VetMedPlus.API.Services.Contracts;

namespace VetMedPlus.API.Interfaces
{
    public class UserData : IUserData
    {
        private PetMedPlusContext _db;

        public UserData(PetMedPlusContext db)
        {
            _db = db;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            var result = await _db.Users.FirstOrDefaultAsync(x => x.UserId == id);
            if (result == null)
            {
                return new User();
            }
            else
            {
                return result;
            }
        }

        public async Task AddUser(User user)
        {
            try
            {
                await _db.Users.AddAsync(user);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it in some other way
                throw new Exception("An error occurred while saving the user.", ex);
            }
        }

        public async Task DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateUser(User user)
        {
            try
            {
                var existingUser = await _db.Users.FindAsync(user.UserId);
                if (existingUser != null)
                {
                    existingUser.Username = user.Username;
                    existingUser.Password = user.Password;

                    _db.Update(existingUser);
                    await _db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it in some other way
                throw new Exception("Error updating user.", ex);
            }

        }

        public async Task AddUserAddress(UserClientModel userClientModel)
        {
            try
            {

                var userTypeIdParameter = new SqlParameter("@UserTypeId", SqlDbType.Int)
                {
                    Value = userClientModel.UserTypeId
                };

                var usernameParameter = new SqlParameter("@Username", SqlDbType.VarChar)
                {
                    Value = userClientModel.Username
                };

                var passwordParameter = new SqlParameter("@Password", SqlDbType.VarChar)
                {
                    Value = userClientModel.Password
                };

                var firstNameParameter = new SqlParameter("@FirstName", SqlDbType.VarChar)
                {
                    Value = userClientModel.FirstName
                };

                var lastNameParameter = new SqlParameter("@LastName", SqlDbType.VarChar)
                {
                    Value = userClientModel.LastName
                };

                var phoneParameter = new SqlParameter("@Phone", SqlDbType.VarChar)
                {
                    Value = userClientModel.Phone
                };

                var emailParameter = new SqlParameter("@Email", SqlDbType.VarChar)
                {
                    Value = userClientModel.Email
                };

                var birthdateParameter = new SqlParameter("@Birthdate", SqlDbType.Date)
                {
                    Value = userClientModel.Birthdate
                };

                var streetParameter = new SqlParameter("@Street", SqlDbType.VarChar)
                {
                    Value = userClientModel.Street
                };

                var postalCodeParameter = new SqlParameter("@PostalCode", SqlDbType.VarChar)
                {
                    Value = userClientModel.PostalCode
                };

                var streetNumberParameter = new SqlParameter("@StreetNumber", SqlDbType.Int)
                {
                    Value = userClientModel.StreetNumber
                };

                var countryParameter = new SqlParameter("@Country", SqlDbType.VarChar)
                {
                    Value = userClientModel.Country
                };

                var cityParameter = new SqlParameter("@City", SqlDbType.VarChar)
                {
                    Value = userClientModel.City
                };

                var isActiveParameter = new SqlParameter("@IsActive", SqlDbType.Bit)
                {
                    Value = userClientModel.IsActive
                };

                await _db.Database.ExecuteSqlRawAsync("EXEC InsertUserClient @UserTypeId, @Username, @Password, @FirstName, @LastName, @Phone, @Email, @Birthdate, @Street, @PostalCode, @StreetNumber, @Country, @City, @IsActive",
                    userTypeIdParameter, usernameParameter, passwordParameter, firstNameParameter, lastNameParameter, phoneParameter, emailParameter, birthdateParameter, streetParameter, postalCodeParameter, streetNumberParameter, countryParameter, cityParameter, isActiveParameter);

            }
            catch (Exception ex)
            {
                // Log the exception or handle it in some other way
                throw new Exception("An error occurred while saving the user.", ex);
            }
        }
    }
}
