﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace kova.api.Models
{
    [ModelMetadataType(typeof(TOrganizationPerson_Metadata))]
    public partial class TOrganizationPerson
    {
        public string Name
        {
            get { return $"{FirstName} {LastName}"; }
        }

        public bool ValidatePassword(string password)
        {
            if (string.IsNullOrEmpty(Salt) || string.IsNullOrEmpty(Hash))
                return false;

            var saltBinary = Convert.FromBase64String(Salt);
            var hashBinary = Convert.FromBase64String(Hash);

            var passwordArray = System.Text.Encoding.UTF8.GetBytes(password);

            byte[] buffer = new byte[Salt.Length + passwordArray.Length];
            Array.Copy(saltBinary, buffer, saltBinary.Length);
            Array.Copy(passwordArray, 0, buffer, saltBinary.Length, passwordArray.Length);

            var hasher = new System.Security.Cryptography.SHA256Managed();
            var calculatedHash = hasher.ComputeHash(passwordArray);

            return calculatedHash.SequenceEqual(hashBinary);
        }

        public void SetPassword(string password)
        {
            var salt = CreateSalt();

            var passwordArray = System.Text.Encoding.UTF8.GetBytes(password);

            byte[] buffer = new byte[salt.Length + passwordArray.Length];
            Array.Copy(salt, buffer, salt.Length);
            Array.Copy(passwordArray, 0, buffer, salt.Length, passwordArray.Length);

            var hasher = new System.Security.Cryptography.SHA256Managed();
            var hash = hasher.ComputeHash(passwordArray);

            this.Salt = Convert.ToBase64String(salt);
            this.Hash = Convert.ToBase64String(hash);
        }

        private static byte[] CreateSalt()
        {
            byte[] buffer = new byte[20];
            var randomizer = new System.Security.Cryptography.RNGCryptoServiceProvider();
            randomizer.GetBytes(buffer);
            return buffer;
        }


        public class TOrganizationPerson_Metadata
        {
            [JsonIgnore]
            public byte[] Salt { get; set; }
        }

    }
}
