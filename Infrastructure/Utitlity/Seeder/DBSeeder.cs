using System;using System.Collections.Generic;using System.Linq;using System.Threading.Tasks;using Techverx.Paysoft.DataContext;using Techverx.Paysoft.Models;using Techverx.Paysoft.Models.BankAccount;using Techverx.Paysoft.Models.Banks;namespace Techverx.Paysoft.Seeder{    public class DBSeeder : IDBSeeder    {        private readonly ContextClass _contextClass;        public DBSeeder(ContextClass contextClass)        {            _contextClass = contextClass;        }        public async Task Seed()        {            if (!_contextClass.Employees.Any())            {                await _contextClass.Employees.AddRangeAsync(new List<Employee>            {                new Employee{ FirstName = "Umer" , Email = "umer@gmail.com", Surname = "Daraz", ClientCode= "111765", CustomerCode ="5477"},                new Employee{ FirstName = "Taqi" , Email = "taqi@gmail.com", Surname = "Shah", ClientCode= "654765", CustomerCode ="3332"},                new Employee{ FirstName = "Danish" , Email = "danish@gmail.com", Surname = "Ali", ClientCode= "654765", CustomerCode ="5466"},                new Employee{ FirstName = "Nashit" , Email = "nashit@gmail.com", Surname = "Butt", ClientCode= "356765", CustomerCode ="7732"},            });            }            _contextClass.SaveChanges();            if (!_contextClass.Banks.Any())            {                await _contextClass.Banks.AddRangeAsync(new List<Bank>            {                new Bank{ Name = "Meezan Bank" , BranchCode = 4331, Reference = "Bank1"},                new Bank{ Name = "BOP Bank" , BranchCode = 5331,Reference = "Bank2" },                new Bank{ Name = "Punjab Bank" , BranchCode = 2331, Reference = "Bank3"},                new Bank{ Name = "Peace Bank" , BranchCode = 1331 , Reference = "Bank4"}            });            }            _contextClass.SaveChanges();            if (!_contextClass.Accounts.Any())            {                await _contextClass.Accounts.AddRangeAsync(new List<Account>            {                new Account{ AccountNumber = "REW5323" , BankId = 1, EmployeeId = 1, AccountType = 0 , BranchCode= 6543323},                new Account{ AccountNumber = "TERE5323" , BankId = 2, EmployeeId = 2, AccountType = 0 , BranchCode= 655523},                new Account{ AccountNumber = "TWEF5323" , BankId = 3, EmployeeId = 3, AccountType = 0 , BranchCode= 1543323},                new Account{ AccountNumber = "TRE5323" , BankId = 4, EmployeeId = 4, AccountType = 0 , BranchCode= 6663323}            });            }            _contextClass.SaveChanges();






















            /* if (!_contextClass.Payments.Any())            {            await _contextClass.Payments.AddRangeAsync(new List<Payment>            {            new Payment{PaymentStatus = false,Initials=424.2343, FileAmount = 433.3, BankId = 1, AccountType = 0 , EmployeeId = 1, AmountMultiplier =0, Reference="This is Payment1"},            new Payment{PaymentStatus = false,Initials=424.2343, FileAmount = 433.3, BankId = 2, AccountType = 0 , EmployeeId = 2, AmountMultiplier =0, Reference="This is Payment2"},            new Payment{PaymentStatus = false,Initials=424.2343, FileAmount = 433.3, BankId = 3, AccountType = 0 , EmployeeId = 3, AmountMultiplier =0, Reference="This is Payment3"},            new Payment{PaymentStatus = false,Initials=424.2343, FileAmount = 433.3, BankId = 4, AccountType = 0 , EmployeeId = 4, AmountMultiplier =0, Reference="This is Payment4"}            });            _contextClass.SaveChanges();*/

        }    }}