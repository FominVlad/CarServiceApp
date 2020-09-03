using System;
using System.ComponentModel.DataAnnotations;
using CarServiceApp.Models.DTOs;

namespace CarServiceApp.ValidationAttributes
{
    public class UpdateLoginPasswordAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            UpdateUserDTO updateUserDTO = value as UpdateUserDTO;

            if (updateUserDTO == null)
                throw new Exception("Object must be a UpdateUserDTO type!");
                

            if ((string.IsNullOrEmpty(updateUserDTO.Login) && !string.IsNullOrEmpty(updateUserDTO.Password)) ||
                (!string.IsNullOrEmpty(updateUserDTO.Login) && string.IsNullOrEmpty(updateUserDTO.Password)))
            {
                ErrorMessage = "When changing login or password, these fields must be filled in both!";

                return false;
            }

            return true;
        }
    }
}
