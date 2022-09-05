﻿using Bookstore;
using Bookstore.Repositories;
using Microsoft.AspNetCore.Mvc;
using Rhetos;
using Rhetos.Dom.DefaultConcepts;
using Rhetos.Logging;
using Rhetos.Processing;
using Rhetos.Processing.DefaultCommands;
using Rhetos.Utilities;
using System.Collections;

[Route("Demo/[action]")]
public class DemoController : ControllerBase
{
    private readonly IProcessingEngine processingEngine;
    private readonly IUnitOfWork unitOfWork;
    private readonly Common.ExecutionContext _context;


    public DemoController(IRhetosComponent<IProcessingEngine> processingEngine, IRhetosComponent<IUnitOfWork> unitOfWork, IRhetosComponent<Common.ExecutionContext> context)
    {
        this.processingEngine = processingEngine.Value;
        this.unitOfWork = unitOfWork.Value;
        _context = context.Value;

    }

    [HttpGet]
    public string ReadBooks()
    {
        var readCommandInfo = new ReadCommandInfo { DataSource = "Bookstore.Book", ReadTotalCount = true };
        var result = processingEngine.Execute(readCommandInfo);

        return $"{result.TotalCount} books.";
    }

    [HttpGet]
    public string WriteBook()
    {
        var newBook = new Bookstore.Book { Title = "NewBook" };
        var saveCommandInfo = new SaveEntityCommandInfo { Entity = "Bookstore.Book", DataToInsert = new[] { newBook } };
        processingEngine.Execute(saveCommandInfo);
        unitOfWork.CommitAndClose(); // Commits and closes database transaction.
        return "1 book inserted.";
    }

    [HttpGet]
    public IEnumerable GetListOfBooks()
    {
 
        return _context.Repository.Bookstore.Book.Load().ToList();
    }

    [HttpGet]
    public IEnumerable GetBookAndAuthorLoad()
    {

        var list = _context.Repository.Bookstore.Book.Load().Select(book => book.Title).ToList();

        return list;
    }

    [HttpGet]
    public IEnumerable GetBookAndAuthorQuery()
    {

        var query = _context.Repository.Bookstore.Book.Query().Select(book => book.Title + '-' + book.Author.Name);
        Console.WriteLine(query.ToString());

        return query.ToList();
    }


    [HttpPost]
    public void GenerateBooks(long numberOfBooks, string title)
    { 

        while(numberOfBooks > 0)
        {

            Random random = new Random();
            _context.Repository.Bookstore.Book.Insert(new Book { Title = title, Code = random.Next(10000).ToString() });
            --numberOfBooks;
        }
    }


}