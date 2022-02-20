using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using essentialMix.Data.Model;
using essentialMix.Extensions;

namespace Identity.Model;

[DebuggerDisplay("{Name} [{Id}]")]
[Serializable]
public class Country : IEntity<string>
{
	private string _name;
	private string _id;

	[Key]
	[StringLength(3, MinimumLength = 3)]
	public string Id
	{
		get => _id;
		set => _id = value.ToNullIfEmpty()?.ToUpperInvariant();
	}

	[Required]
	[StringLength(255)]
	public string Name
	{
		get => _name;
		set => _name = value.ToNullIfEmpty();
	}
}