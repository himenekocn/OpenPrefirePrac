
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Memory;
using CounterStrikeSharp.API.Modules.Utils;
using CounterStrikeSharp.API.Core.Attributes;

namespace OpenPrefirePrac;

public partial class CCSBots : CBot
{
    public CCSBots (IntPtr pointer) : base(pointer) {}

    [SchemaMember("CCSBot", "m_lookAtSpot")]
    public Vector SetlookAtSpot
	{
		set { Schema.SetSchemaValue<Vector>(this.Handle, "CCSBot", "m_lookAtSpot", value); }
	}
}