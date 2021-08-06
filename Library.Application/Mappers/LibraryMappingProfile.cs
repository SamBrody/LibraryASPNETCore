using AutoMapper;
using Library.Application.Dto;
using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Mappers
{
    public class LibraryMappingProfile : Profile
    {
        public LibraryMappingProfile()
        {
            CreateMap<Author, AuthorDTO>();
            CreateMap<AuthorBook, AuthorBookDTO>().ConstructUsing(i => new AuthorBookDTO
            {
                Id = i.Id,
                AuthorsDTOObj = i.AuthorsObj,
                AuthorId = i.AuthorId,
                BooksDTOObj = i.BooksObj,
                BookId = i.BookId
            });
            CreateMap<Book, BookDTO>().ConstructUsing(i => new BookDTO
            {
                Id = i.Id,
                PhotoPath = i.PhotoPath,                
                TakeDate = i.TakeDate,
                Title = i.Title,
                ShelfId = i.ShelfId,
                ShelfDTOObj = i.ShelfObj,
                ReaderId = i.ReaderId,
                ReaderDTOObj = i.ReaderObj,                
            });
            CreateMap<BookCategory, BookCategoryDTO>().ConstructUsing(i => new BookCategoryDTO
            {
                Id = i.Id,                
                BookId = i.BookId,
                BookObj = i.BookObj,                
                CategoryId = i.CategoryId,
                CategoryObj = i.CategoryObj                
            }); 
            CreateMap<BookTag, BookTagDTO>().ConstructUsing(i => new BookTagDTO
            {
                Id = i.Id,
                BookObj = i.BookObj,
                BookId = i.BookId,
                TagObj = i.TagObj,
                TagId = i.TagId
            });
            CreateMap<Category, CategoryDTO>().ConstructUsing(i => new CategoryDTO
            {
                Id = i.Id,
                Name = i.Name,
                BookCategoryObj = i.BookCategoryObj
            });
            CreateMap<Reader, ReaderDTO>().ConstructUsing(i => new ReaderDTO
            {
                Id = i.Id,
                BirthDate = i.BirthDate,
                RegistrationDate = i.RegistrationDate,                
                FullName = i.FullName,                
                BookObj = i.BookObj
            });
            CreateMap<Shelf, ShelfDTO>().ConstructUsing(i => new ShelfDTO
            {
                Id = i.Id,
                Name = i.Name,
                BookObj = i.BookObj
            });
            CreateMap<Tag, TagDTO>().ConstructUsing(i => new TagDTO
            {
                Id = i.Id,
                Name = i.Name,
                BookTagObj = i.BookTagObj
            });
        }
    }
}
