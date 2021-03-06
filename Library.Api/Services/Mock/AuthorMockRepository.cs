﻿using System;
using System.Collections.Generic;
using System.Linq;
using Library.Api.Data;
using Library.Api.Models;

namespace Library.Api.Services.Mock {
    public class AuthorMockRepository : IAuthorMockRepository {
        public IEnumerable<AuthorDto> GetAuthors() {
            return LibraryMockData.Current.Authors;
        }

        public AuthorDto GetAuthor(Guid authorId) {
            return LibraryMockData.Current.Authors.FirstOrDefault(item => item.Id == authorId);
        }

        public bool IsAuthorExists(Guid authorId) {
            return LibraryMockData.Current.Authors.Any(item => item.Id == authorId);
        }

        public void AddAuthor(AuthorDto author) {
            author.Id = Guid.NewGuid();
            LibraryMockData.Current.Authors.Add(author);
        }

        public void DeleteAuthor(AuthorDto author) {
            LibraryMockData.Current.Books.RemoveAll(book => book.AuthorId == author.Id);
            LibraryMockData.Current.Authors.Remove(author);
        }
    }
}