
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Memory;
using CounterStrikeSharp.API.Modules.Utils;
using CounterStrikeSharp.API.Core.Attributes;

namespace OpenPrefirePrac;

public partial class CCSBotWrite : CBot
{
    public CCSBotWrite (IntPtr pointer) : base(pointer) {}

    [SchemaMember("CCSBot", "m_lookAtSpot")]
    public Vector SetlookAtSpot
	{
		set { Schema.SetSchemaValue<Vector>(this.Handle, "CCSBot", "m_lookAtSpot", value); }
	}
}