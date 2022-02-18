using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using essentialMix.Data.Model;
using essentialMix.Extensions;

namespace Identity.Core.Model;

[DebuggerDisplay("{Name} [{CountryId}]")]
[Serializable]
public class City : IEntity<int>
{
	private string _name;

	[Key]
	public int Id { get; set; }

	[Required]
	[StringLength(255)]
	public string Name
	{
		get => _name;
		set => _name = value.ToNullIfEmpty();
	}

	[Required]
	[StringLength(3, MinimumLength = 3)]
	public string CountryId { get; set; }

	public virtual Country Country { get; set; }
}