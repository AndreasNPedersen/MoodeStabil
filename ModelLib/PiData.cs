﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace ModelLib
{
    public partial class PiData
    {
        public PiData()
        {
        }
        public PiData(DateTime? dateFromSubject, DateTime? date, Subjects subject)
        {
            DateFromSubject = dateFromSubject;
            Date = date;
            Subject = subject;
            SubjectId = subject.Id;
        }

        private DateTime? _dateFromSubject;
        private DateTime? _date;
        private Subjects _subject;


        public int Id { get; set; }
        public DateTime? DateFromSubject 
        {
            get => _dateFromSubject; 
            set
            {
                if (value == null) throw new ArgumentNullException();
                _dateFromSubject = value;
            }
        }
        public DateTime? Date
        {
            get => _date;
            set
            {
                if (value == null) throw new ArgumentNullException();
                _date = value;
            }
        }
        public int? SubjectId { get; set; }

        public virtual Subjects Subject
        {
            get => _subject;
            set
            {
                if (value == null) throw new ArgumentNullException();
                _subject = value;
            }
        }


        public override bool Equals(object obj)
        {
            return obj is PiData data &&
                   Id == data.Id &&
                   DateFromSubject.Value.Date.Day == data.DateFromSubject.Value.Date.Day &&
                   Date.Value.Day == data.Date.Value.Day &&
                   SubjectId == data.SubjectId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, DateFromSubject, Date, SubjectId, Subject);
        }
    }
}