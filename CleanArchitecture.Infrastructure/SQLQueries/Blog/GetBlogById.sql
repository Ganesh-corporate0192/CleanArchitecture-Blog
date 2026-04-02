SELECT
    Id,
    Name,
    Description,
    Author,
    ImageUrl
FROM Blogs
WHERE Id = @Id;