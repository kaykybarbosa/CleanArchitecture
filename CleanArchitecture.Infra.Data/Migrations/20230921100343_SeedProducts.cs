using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO PRODUCTS(Name, Description, Price, Stock, Image, CategoryId)" +
                "VALUES ('Security Camera', 'Night Vision, Alarm and Baby Monitor Function', 150.99, 50, 'https://imgs.search.brave.com/aOqRBUjbyVZg8jA9oOgp6dykMnx1ZQu2sgGm8ONhugY/rs:fit:860:0:0/g:ce/aHR0cHM6Ly9pbWFn/ZXMtbmEuc3NsLWlt/YWdlcy1hbWF6b24u/Y29tL2ltYWdlcy9J/LzQxK3NzNXlySWhM/LmpwZw', 2)");
        
            mb.Sql("INSERT INTO PRODUCTS(Name, Description, Price, Stock, Image, CategoryId)" +
                "VALUES ('Headset', 'Bluetooth headset with microphone and power for total 18 hours', 99.99, 100, 'https://imgs.search.brave.com/XEkjGfYkevmgW28Zum_Q8Fh23f7tbGo9tSVqhO30aR4/rs:fit:860:0:0/g:ce/aHR0cHM6Ly9pbWFn/ZXMtbmEuc3NsLWlt/YWdlcy1hbWF6b24u/Y29tL2ltYWdlcy9J/LzMxOVRIbzVERnZM/LmpwZw', 2)");
            
            mb.Sql("INSERT INTO PRODUCTS(Name, Description, Price, Stock, Image, CategoryId)" +
                "VALUES ('Schoolbag', 'Original Black Hang Loose Schoolbag', 56.99, 200, 'https://imgs.search.brave.com/nR8LUL7gF2nwHILCBjzVNIdPi7MfSd8Ldpt4hxcrkY4/rs:fit:860:0:0/g:ce/aHR0cHM6Ly9tLm1l/ZGlhLWFtYXpvbi5j/b20vaW1hZ2VzL0kv/NTFVVkNmdVNoZkwu/anBn', 1)");
            
            mb.Sql("INSERT INTO PRODUCTS(Name, Description, Price, Stock, Image, CategoryId)" +
                "VALUES ('Notebook', 'Notebook Brochure 1 Subject Yellow 80 sheets', 15.50, 50, 'https://imgs.search.brave.com/lEbPCVZiKMUH9CKZkIWUPB1KyJKNkR9EeFOKPO_nibA/rs:fit:860:0:0/g:ce/aHR0cHM6Ly9pbWFn/ZXMudGNkbi5jb20u/YnIvaW1nL2ltZ19w/cm9kLzgzNjExNy8x/ODBfY2FkX2Jyb2No/X2NkX3VuaXZfZF9h/bV80OGZfMjkzN18x/XzIwMjAwODIxMTYz/NjQ0LmpwZw', 1)");
            
            mb.Sql("INSERT INTO PRODUCTS(Name, Description, Price, Stock, Image, CategoryId)" +
                "VALUES ('Chain', 'Caroline Stainless Steel Chain Necklace', 520.99, 20, 'https://imgs.search.brave.com/MkDsi1njOluXtCJLJkbi5JHvQ5G6re5IXVcd0P11gN0/rs:fit:860:0:0/g:ce/aHR0cHM6Ly9mYXNo/aW9uYmlqdS52dGV4/aW1nLmNvbS5ici9h/cnF1aXZvcy9pZHMv/MTgxMzExLTMwMC0z/MDAvVW50aXRsZWQt/ZGVzaWduLS0yOS0u/cG5nP3Y9NjM4MjY2/NzY3MzA4MzMwMDAw', 3)");
        
             mb.Sql("INSERT INTO PRODUCTS(Name, Description, Price, Stock, Image, CategoryId)" +
                "VALUES ('Glasses', 'Retro Acetate Cat Sunglasses', 120.00, 59, 'https://imgs.search.brave.com/qmBeD7dpI4R62ayhHRcz0xP3GtQhXCsYShpNLuf5_iE/rs:fit:860:0:0/g:ce/aHR0cHM6Ly9tLm1l/ZGlhLWFtYXpvbi5j/b20vaW1hZ2VzL0kv/NDFjLXpQTzBIWUwu/anBn', 3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM PRODUCTS");
        }
    }
}
