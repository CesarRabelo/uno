#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.System.Profile
{
	#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class AppApplicability 
	{
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __MACOS__
		[global::Uno.NotImplemented]
		public static global::System.Collections.Generic.IReadOnlyList<global::Windows.System.Profile.UnsupportedAppRequirement> GetUnsupportedAppRequirements( global::System.Collections.Generic.IEnumerable<string> capabilities)
		{
			throw new global::System.NotImplementedException("The member IReadOnlyList<UnsupportedAppRequirement> AppApplicability.GetUnsupportedAppRequirements(IEnumerable<string> capabilities) is not implemented in Uno.");
		}
		#endif
	}
}