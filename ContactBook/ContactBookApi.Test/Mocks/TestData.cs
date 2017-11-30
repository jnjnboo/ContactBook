using System;
using System.Collections.Generic;
using ContactBookApi.Models;

namespace ContactBookApi.Test.Mocks
{
    public static class TestData
    {
        public static void SeedDbAddressTypes(this ContactBookContext context)
        {
            context.AddressType.AddRange(CreateTestAddressTypes());
            context.SaveChanges();
        }

        public static void SeedDbEmailTypes(this ContactBookContext context)
        {
            context.EmailType.AddRange(CreateTestEmailTypes());
            context.SaveChanges();
        }

        public static void SeedDbEventTypes(this ContactBookContext context)
        {
            context.EventType.AddRange(CreateTestEventTypes());
            context.SaveChanges();
        }

        public static void SeedDbPhoneTypes(this ContactBookContext context)
        {
            context.PhoneType.AddRange(CreateTestPhoneTypes());
            context.SaveChanges();
        }

        public static void SeedDbWebsiteTypes(this ContactBookContext context)
        {
            context.WebsiteType.AddRange(CreateTestWebsiteTypes());
            context.SaveChanges();
        }

        public static int SeedDbContacts(this ContactBookContext context)
        {
            SeedDbEmailTypes(context);
            SeedDbPhoneTypes(context);
            SeedDbWebsiteTypes(context);
            var user = CreateUser();
            context.Add(user);
            context.Contact.AddRange(CreateContacts(user));
            context.SaveChanges();
            return user.UserId;
        }

        private static IEnumerable<AddressType> CreateTestAddressTypes()
        {
            return new List<AddressType> {
                new AddressType { AddressTypeId = 1, Name = "Home" },
                new AddressType { AddressTypeId = 2, Name = "Business" }
            };
        }

        private static IEnumerable<EmailType> CreateTestEmailTypes()
        {
            return new List<EmailType>
            {
                new EmailType { EmailTypeId = 1, Name = "Business" },
                new EmailType { EmailTypeId = 2, Name = "Personal" }
            };
        }

        private static IEnumerable<EventType> CreateTestEventTypes()
        {
            return new List<EventType>
            {
                new EventType { EventTypeId = 1, Name = "Anniversary" },
                new EventType { EventTypeId = 2, Name = "Birthday" },
                new EventType { EventTypeId = 3, Name = "Other" }
            };
        }

        private static IEnumerable<PhoneType> CreateTestPhoneTypes()
        {
            return new List<PhoneType>
            {
                new PhoneType { PhoneTypeId = 1, Name = "Home" },
                new PhoneType { PhoneTypeId = 2, Name = "Business" },
                new PhoneType { PhoneTypeId = 3, Name = "Home Fax" },
                new PhoneType { PhoneTypeId = 4, Name = "Business Fax" },
                new PhoneType { PhoneTypeId = 5, Name = "Pager" }
            };
        }

        private static IEnumerable<WebsiteType> CreateTestWebsiteTypes()
        {
            return new List<WebsiteType>
            {
                new WebsiteType { WebsiteTypeId = 1, Name = "Personal" },
                new WebsiteType { WebsiteTypeId = 2, Name = "Business" },
                new WebsiteType { WebsiteTypeId = 3, Name = "Blog" },
                new WebsiteType { WebsiteTypeId = 4, Name = "Profile" }
            };
        }
        private static User CreateUser()
        {
            return new User
            {
                FullName = "Test User", PreferredName ="T-dog", Active = true, CreatedDate = DateTime.UtcNow
            };
        }

        private static IEnumerable<Contact> CreateContacts(User user)
        {
            return new List<Contact>
            {
                new Contact
                {
                    UserId = user.UserId, Name = "Satya Nadella", Company = "Microsoft", JobTitle = "CEO", CreatedDate = DateTime.UtcNow,
                    Email = new Email[]
                    {
                        new Email
                        {
                           EmailAddress = "snadella@microsoft.com", EmailTypeId = 2
                        }
                    },
                    Website = new Website[]
                    {
                        new Website
                        {
                            Url = "www.microsoft.com", WebsiteTypeId = 2
                        }
                    },
                    Phone = new Phone[]
                    {
                        new Phone
                        {
                            Number = "206-555-1234", PhoneTypeId = 1
                        }
                    }
                },
                new Contact
                {
                    UserId = user.UserId, Name = "Ginni Rometty", Company = "IBM", JobTitle = "President & CEO", CreatedDate = DateTime.UtcNow,
                    Email = new Email[]
                    {
                        new Email
                        {
                            EmailAddress = "grometty@ibm.com", EmailTypeId = 2
                        }
                    },
                    Website = new Website[]
                    {
                        new Website
                        {
                            Url = "www.ibm.com", WebsiteTypeId = 2
                        }
                    },
                    Phone = new Phone[]
                    {
                        new Phone
                        {
                            Number = "415-555-5678", PhoneTypeId = 1
                        }
                    }
                }
            };
        }
    }
}
