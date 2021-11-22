﻿using System;
using System.IO;
using System.Reflection;
using AutoMapper;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using OrderMaker.Converters.DTO;
using OrderMaker.Models;
using OrderMaker.Models.Utils;
using JsonConverter = OrderMaker.Converters.JsonConverter;

namespace OrderMaker.UnitTests.Converters
{
    public class OrderJsonConverterTests
    {
        private Order? _order;
        private string? _orderString;
        private JsonConverter? _converter;
        private const string TestDataPath = "TestData";
        private const string OrderTestFile1 = "Order1.json";

        [SetUp]
        public void Setup()
        {
          var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
          var orderTestFilePath = Path.Combine(assemblyPath ?? "", TestDataPath, OrderTestFile1);

          _orderString = File.ReadAllText(orderTestFilePath);
          
          var config = new MapperConfiguration(cfg =>
          {
            cfg.CreateMap<ArrangementDto, (string Where, string What)>()
              .ConvertUsing(i => new ValueTuple<string, string>(i.Where, i.What));
            cfg.CreateMap<(string Where, string What), ArrangementDto>()
              .ConvertUsing(i => new ArrangementDto { Where = i.Where, What = i.What });
            cfg.CreateMap<PermissionAdmitDto, (string Who, DateTime? When)>()
              .ConvertUsing(i => new ValueTuple<string, DateTime?>(i.Who, i.When));
            cfg.CreateMap<(string Who, DateTime? When), PermissionAdmitDto>()
              .ConvertUsing(i => new PermissionAdmitDto { Who = i.Who, When = i.When });
            cfg.CreateMap<PersonDto, Person>();
            cfg.CreateMap<Person, PersonDto>();
            cfg.CreateMap<OrderDto, Order>();
            cfg.CreateMap<Order, OrderDto>();
          });
          var mapper = new Mapper(config);
          var settings = new JsonSerializerSettings
          {
            NullValueHandling = NullValueHandling.Ignore,
            Formatting = Formatting.Indented
          };

          _converter = new JsonConverter(settings, mapper);

          var person0 = new PersonBuilder()
            .SetName("Не назначается")
            .IsSupervisor
            .Build();

          var person1 = new PersonBuilder()
            .SetName("------------")
            .IsWatcher
            .Build();

          var person2 = new PersonBuilder()
            .SetName("Иванов И.И.")
            .SetAdditionalName("Иванову И.И.")
            .SetGroup(GroupType.Five)
            .IsMaker
            .IsAdmitter
            .Build();

          var person3 = new PersonBuilder()
            .SetName("Петров П.П.")
            .SetAdditionalName("Петрову П.П.")
            .SetGroup(GroupType.Three)
            .IsMember
            .Build();

          var person4 = new PersonBuilder()
            .SetName("Сидоров С.С.")
            .SetAdditionalName("Сидорову С.С.")
            .SetSpeciality("диспетчер")
            .SetGroup(GroupType.Five)
            .IsIssuer
            .IsDispatcher
            .Build();

          _order = new OrderBuilder()
            .SetName("Test order 1")
            .SetNumber("1-O")
            .SetCompany(@"Кабельная сеть ПАО""Россети"" ""Ленэнерго""")
            .SetSubdivision("Невский РЭС")
            .SetSupervisor(person0)
            .SetAdmitter(person2)
            .SetMaker(person2)
            .SetWatcher(person1)
            .SetIssuer(person4)
            .SetDispatcher(person4)
            .SetBriefingListener(person2)
            .AddMember(person3)
            .AddAssignment("Поручается произвести испытание фХ-ХХХ из РПХХХХ")
            .AddArrangement("РПХХХХ", "В, КР, ШР фХ-ХХХ")
            .AddArrangement("ПCХХХ", "В, Выкачена тележка фХ-ХХХ в ремонтное положение")
            .AddArrangement("РПХХХХ", "Вкл ЗНКР и ЗНШР фХ-ХХХ")
            .AddInstruction(
              "На время производства работ, разрешается производителю работ отключать ЗН фХ-ХХХ, с последующим включением")
            .AddPermissionAdmit(person4.GetNameWithGroupAndSpeciality(), new DateTime(2021, 11, 6 , 8, 30, 0))
            .SetIssue(new DateTime(2021, 11, 6, 8, 0, 0))
            .SetWorkBegin(new DateTime(2021, 11, 6, 9, 30, 0))
            .SetWorkEnd(new DateTime(2021, 11, 6, 20, 0, 0))
            .Build();
        }

        [Test]
        public void OrderJsonConverter_Should_Serialize_Order()
        {
            var orderJson = _converter?.Serialize<Order, OrderDto>(_order!);
            orderJson.Should().BeEquivalentTo(_orderString);
        }
        
        [Test]
        public void OrderJsonConverter_Should_Deserialize_Order()
        {
            var orderResult = _converter?.Deserialize<Order, OrderDto>(_orderString!);
            orderResult.Should().BeEquivalentTo(_order);
        }
    }
}