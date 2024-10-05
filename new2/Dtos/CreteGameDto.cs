using System.ComponentModel.DataAnnotations;

namespace new2.Dtos;

public record class CreteGameDto
(
 [Required][StringLength(50)]string Name,
 [Required][StringLength(20)]string Genre,
 [Required][Range(1,50)]decimal Price,
 DateOnly ReleaseDate
);
