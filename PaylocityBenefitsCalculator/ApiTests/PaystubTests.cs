using Api.Dtos.Dependent;
using Api.Dtos.Employee;
using Api.Dtos.Payroll;
using Api.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace ApiTests
{
    public class PaystubTests
    {
        
        [Fact]
        public void Paystub_GrossWage_78000()
        {
            GetPaystubDto response = new GetPaystubDto(Employee1);

            Assert.True(3000 == response.GrossWages);
        }

        [Fact]
        public void Paystub_GrossWage_100000()
        {
            GetPaystubDto response = new GetPaystubDto(Employee2);

            Assert.True(3846.15m == Math.Round(response.GrossWages, 2));
        }

        [Fact]
        public void Paystub_BaseBenefit()
        {
            GetPaystubDto response = new GetPaystubDto(Employee1);

            Assert.True(461.54m == Math.Round(response.BaseBenefits, 2));
        }

        [Fact]
        public void Paystub_DependentBenefits_NoDependents()
        {
            GetPaystubDto response = new GetPaystubDto(Employee1);

            Assert.True(0 == Math.Round(response.DependentBenefits, 2));
        }

        [Fact]
        public void Paystub_DependentBenefits_OneDependent()
        {
            GetPaystubDto response = new GetPaystubDto(Employee2);

            Assert.True(276.92m == Math.Round(response.DependentBenefits, 2));
        }

        [Fact]
        public void Paystub_DependentBenefits_ThreeDependents()
        {
            GetPaystubDto response = new GetPaystubDto(Employee3);

            Assert.True(830.77m == Math.Round(response.DependentBenefits, 2));
        }

        [Fact]
        public void Paystub_Highwage_No()
        {
            GetPaystubDto response = new GetPaystubDto(Employee1);

            Assert.True(0 == response.HighWagePremium);
        }

        [Fact]
        public void Paystub_Highwage_100000()
        {
            GetPaystubDto response = new GetPaystubDto(Employee2);

            Assert.True(76.92m == Math.Round(response.HighWagePremium, 2));
        }

        [Fact]
        public void Paystub_Highwage_130000()
        {
            GetPaystubDto response = new GetPaystubDto(Employee3);

            Assert.True(100m == response.HighWagePremium);
        }

        [Fact]
        public void Paystub_Senior_None()
        {
            GetPaystubDto response = new GetPaystubDto(Employee1);

            Assert.True(0 == Math.Round(response.SeniorPremium, 2));
        }

        [Fact]
        public void Paystub_Senior_One()
        {
            GetPaystubDto response = new GetPaystubDto(Employee2);

            Assert.True(92.31m == Math.Round(response.SeniorPremium, 2));
        }

        [Fact]
        public void Paystub_Senior_OneAlso()
        {
            GetPaystubDto response = new GetPaystubDto(Employee3);

            Assert.True(92.31m == Math.Round(response.SeniorPremium, 2));
        }

        [Fact]
        public void Paystub_Senior_Two()
        {
            GetPaystubDto response = new GetPaystubDto(Employee4);

            Assert.True(184.62m == Math.Round(response.SeniorPremium, 2));
        }

        [Fact]
        public void Paystub_NetWage_Employee1()
        {
            GetPaystubDto response = new GetPaystubDto(Employee1);

            Assert.True(2538.46m == Math.Round(response.NetWages, 2));
        }

        [Fact]
        public void Paystub_NetWage_Employee2()
        {
            GetPaystubDto response = new GetPaystubDto(Employee2);

            Assert.True(2938.46m == Math.Round(response.NetWages, 2));
        }



        private static readonly GetEmployeeDto Employee1 = new()
        {
            Id = 1,
            FirstName = "LowSalary",
            LastName = "NoDependents",
            Salary = 78000,
            DateOfBirth = new DateTime(1984, 12, 30)
        };

        private static readonly GetEmployeeDto Employee2 = new()
        {
            Id = 1,
            FirstName = "HighSalary",
            LastName = "OneDependent",
            Salary = 100000,
            DateOfBirth = new DateTime(1984, 12, 30),
            Dependents = new List<GetDependentDto>()
            { 
               new()
               {
                   Id = 1,
                   FirstName = "Dependent",
                   LastName = "Elderly",
                   Relationship = Relationship.Spouse,
                   DateOfBirth = DateTime.Today.AddYears(-52)
               }
            }
        };

        private static readonly GetEmployeeDto Employee3 = new()
        {
            Id = 1,
            FirstName = "HighSalary",
            LastName = "ThreeDependents",
            Salary = 130000,
            DateOfBirth = new DateTime(1950, 12, 30),
            Dependents = new List<GetDependentDto>()
            {
               new()
               {
                   Id = 1,
                   FirstName = "Dependent",
                   LastName = "Elderly",
                   Relationship = Relationship.Spouse,
                   DateOfBirth = DateTime.Today.AddYears(-52)
               },
               new()
               {
                   Id = 2,
                   FirstName = "Dependent",
                   LastName = "Young",
                   Relationship = Relationship.Child,
                   DateOfBirth = DateTime.Today.AddYears(-22)
               },
               new()
               {
                   Id = 3,
                   FirstName = "Dependent",
                   LastName = "NotQuiteElderly",
                   Relationship = Relationship.Child,
                   DateOfBirth = DateTime.Today.AddYears(-51).AddDays(1)
               }

            }
        };

        private static readonly GetEmployeeDto Employee4 = new()
        {
            Id = 1,
            FirstName = "HighSalary",
            LastName = "ThreeDependents",
            Salary = 130000,
            DateOfBirth = new DateTime(1950, 12, 30),
            Dependents = new List<GetDependentDto>()
            {
               new()
               {
                   Id = 1,
                   FirstName = "Dependent",
                   LastName = "Young",
                   Relationship = Relationship.Spouse,
                   DateOfBirth = DateTime.Today.AddYears(-22)
               },
               new()
               {
                   Id = 2,
                   FirstName = "Dependent",
                   LastName = "Young",
                   Relationship = Relationship.Child,
                   DateOfBirth = DateTime.Today.AddYears(-22)
               },
               new()
               {
                   Id = 3,
                   FirstName = "Dependent",
                   LastName = "Elderly",
                   Relationship = Relationship.Child,
                   DateOfBirth = DateTime.Today.AddYears(-52)
               },
               new()
               {
                   Id = 3,
                   FirstName = "Dependent",
                   LastName = "Elderly",
                   Relationship = Relationship.Child,
                   DateOfBirth = DateTime.Today.AddYears(-52)
               }


            }
        };

    }
}
