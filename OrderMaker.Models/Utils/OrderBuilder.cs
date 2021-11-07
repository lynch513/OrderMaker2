using System;
using System.Collections.Generic;

namespace OrderMaker.Models.Utils
{
    public class OrderBuilder
    {
        private readonly Order _order;

        public OrderBuilder()
        {
            _order = new Order();
        }

        // Заголовок
        
        public OrderBuilder SetNumber(string number)
        {
            _order.Number = number;
            return this;
        }

        public OrderBuilder SetCompany(string company)
        {
            _order.Company = company;
            return this;
        }

        public OrderBuilder SetSubdivision(string subdivision)
        {
            _order.Subdivision = subdivision;
            return this;
        }

        // Ответственные за безопасное проведение работ
        
        public OrderBuilder SetSupervisor(Person person)
        {
            _order.Supervisor = person;
            return this;
        }

        public OrderBuilder SetAdmitter(Person person)
        {
            _order.Admitter = person;
            return this;
        }

        public OrderBuilder SetMaker(Person person)
        {
            _order.Maker = person;
            return this;
        }
        
        public OrderBuilder SetWatcher(Person person)
        {
            _order.Watcher = person;
            return this;
        }
        
        public OrderBuilder SetIssuer(Person person)
        {
            _order.Issuer = person;
            return this;
        }
        
        public OrderBuilder SetBriefingListener(Person person)
        {
            _order.BriefingListener = person;
            return this;
        }
        
        public OrderBuilder SetDispatcher(Person person)
        {
            _order.Dispatcher = person;
            return this;
        }

        public OrderBuilder AddMember(Person person)
        {
            _order.Members.Add(person);
            return this;
        }
        
        // Служебные поля

        public OrderBuilder SetName(string name)
        {
            _order.Name = name;
            return this;
        }
        
        // Содержание работ

        public OrderBuilder AddAssignment(string assignment)
        {
            _order.Assignments.Add(assignment);
            return this;
        }

        public OrderBuilder AddArrangement(string @where, string what)
        {
            _order.Arrangements.Add((@where, what));
            return this;
        }

        public OrderBuilder AddInstruction(string instruction)
        {
            _order.Instructions.Add(instruction);
            return this;
        }

        public OrderBuilder AddPermissionAdmit(string who, DateTime when)
        {
            _order.PermissionAdmit.Add((who, when));
            return this;
        }
        
        // Дата и время

        public OrderBuilder SetIssue(DateTime dateTime)
        {
            _order.Issue = dateTime;
            return this;
        }
        
        public OrderBuilder SetWorkBegin(DateTime workBegin)
        {
            _order.WorkBegin = workBegin;
            return this;
        }
        
        public OrderBuilder SetWorkEnd(DateTime workEnd)
        {
            _order.WorkEnd = workEnd;
            return this;
        }

        public Order Build()
        {
            return _order;
        }
    }
}