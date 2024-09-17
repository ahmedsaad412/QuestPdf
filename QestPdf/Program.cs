using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;

Document.Create(container =>
{
    container.Page(page =>
    {
        page.Size(PageSizes.A4);
        page.Margin(25);
        //page.ContentFromLeftToRight();
        //page.ContentFromRightToLeft();
        page.DefaultTextStyle(x=>x.FontSize(16));
        page.Header().Element(Header);

        page.Content().Element(Content);

        page.Footer().Element(Footer);
    });
}).ShowInPreviewer();

void Header (IContainer container)
{

    container.Row(row =>
    {

        row.ConstantItem(150)
        .PaddingTop(50)
        .Height(80)
       .Text("hello hi hi ")
       .FontSize(26).FontColor(Colors.Orange.Accent4).SemiBold();

        row.RelativeItem().PaddingTop(50).Height(80).Column(column =>

        {
            column.Item().Text("bla bla bla blasss").AlignCenter();
            column.Item().Text("ghhshshshd ssdsd").AlignCenter();
            column.Item().Text("احمد سعد  ").AlignCenter();
        });
        row.RelativeItem().Height(80).Column(column =>
        {
            column.Item().AlignCenter().Height(40).Width(40).Image("favicon.ico");
            column.Item().AlignCenter().Text("hello hi hi ")
             .FontColor(Colors.Orange.Accent4).SemiBold();
            column.Item().AlignCenter().Text(Placeholders.Label());
        });


    });
}
void Content (IContainer container)
{
    container.PaddingBottom(1).Table(table =>
    {
        
        table.ColumnsDefinition(columns =>
        { //# , product name ,quantity , price per item , total price
            columns.ConstantColumn(50);
            columns.ConstantColumn(250);
            columns.RelativeColumn();        
            columns.RelativeColumn();
            columns.RelativeColumn();
            
        });
        table.Header(header =>
        {

            header.Cell().Element(headerBlock).Text("#");
            header.Cell().Element(headerBlock).Text("Product Name");
            header.Cell().Element(headerBlock).Text("Quantity");
            header.Cell().Element(headerBlock).Text("Price");
            header.Cell().Element(headerBlock).Text("Total Price");

        });

        foreach(var i in Enumerable.Range(0, 500))
        {
            
            var quantity = Placeholders.Random.Next(1, 30);
            var price = Placeholders.Random.NextDouble()*100;
            var total =quantity *price;
            table.Cell().Element(Block).Text($"{i+1}");
            table.Cell().Element(Block).MaxWidth(240).Text("hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh");
            table.Cell().Element(Block).Text($"{quantity}");
            table.Cell().Element(Block).Text($"{price:F2} $");
            table.Cell().Element(Block) .Text($"{total:F2} $");
        }
    });
}
void Footer (IContainer container)
{
    container.AlignCenter().Text(text =>
    {
        text.DefaultTextStyle(x => x.FontSize(16));
        text.Span("Page Number ");
        text.CurrentPageNumber();
        text.Span(" of ").FontColor(Colors.Orange.Accent4).Underline();
        text.TotalPages();
    });
}
static IContainer Block(IContainer container)
{
    return container
        .Border(1)
        .Background(Colors.Grey.Lighten3)
 
        .ShowOnce()
      
        .MinHeight(10)
        .AlignCenter()
         ;
}static IContainer headerBlock(IContainer container)
{
    return container
        .Border(1)
        .Background(Colors.Grey.Lighten3)
        .PaddingBottom(1)
        
        .ShowOnce()
        .MinWidth(50)
        .MinHeight(50)
        .AlignCenter()
        .AlignMiddle();
}