<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="EnglishSchoolManager" generation="1" functional="0" release="0" Id="e1848d2b-9d74-4d7b-b234-a1a89ef25b06" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="EnglishSchoolManagerGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="ESMWeb:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/EnglishSchoolManager/EnglishSchoolManagerGroup/LB:ESMWeb:Endpoint1" />
          </inToChannel>
        </inPort>
        <inPort name="ESMWeb:Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput" protocol="tcp">
          <inToChannel>
            <lBChannelMoniker name="/EnglishSchoolManager/EnglishSchoolManagerGroup/LB:ESMWeb:Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="Certificate|ESMWeb:Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" defaultValue="">
          <maps>
            <mapMoniker name="/EnglishSchoolManager/EnglishSchoolManagerGroup/MapCertificate|ESMWeb:Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" />
          </maps>
        </aCS>
        <aCS name="ESMWeb:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/EnglishSchoolManager/EnglishSchoolManagerGroup/MapESMWeb:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="ESMWeb:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountEncryptedPassword" defaultValue="">
          <maps>
            <mapMoniker name="/EnglishSchoolManager/EnglishSchoolManagerGroup/MapESMWeb:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountEncryptedPassword" />
          </maps>
        </aCS>
        <aCS name="ESMWeb:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountExpiration" defaultValue="">
          <maps>
            <mapMoniker name="/EnglishSchoolManager/EnglishSchoolManagerGroup/MapESMWeb:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountExpiration" />
          </maps>
        </aCS>
        <aCS name="ESMWeb:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountUsername" defaultValue="">
          <maps>
            <mapMoniker name="/EnglishSchoolManager/EnglishSchoolManagerGroup/MapESMWeb:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountUsername" />
          </maps>
        </aCS>
        <aCS name="ESMWeb:Microsoft.WindowsAzure.Plugins.RemoteAccess.Enabled" defaultValue="">
          <maps>
            <mapMoniker name="/EnglishSchoolManager/EnglishSchoolManagerGroup/MapESMWeb:Microsoft.WindowsAzure.Plugins.RemoteAccess.Enabled" />
          </maps>
        </aCS>
        <aCS name="ESMWeb:Microsoft.WindowsAzure.Plugins.RemoteForwarder.Enabled" defaultValue="">
          <maps>
            <mapMoniker name="/EnglishSchoolManager/EnglishSchoolManagerGroup/MapESMWeb:Microsoft.WindowsAzure.Plugins.RemoteForwarder.Enabled" />
          </maps>
        </aCS>
        <aCS name="ESMWebInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/EnglishSchoolManager/EnglishSchoolManagerGroup/MapESMWebInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:ESMWeb:Endpoint1">
          <toPorts>
            <inPortMoniker name="/EnglishSchoolManager/EnglishSchoolManagerGroup/ESMWeb/Endpoint1" />
          </toPorts>
        </lBChannel>
        <lBChannel name="LB:ESMWeb:Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput">
          <toPorts>
            <inPortMoniker name="/EnglishSchoolManager/EnglishSchoolManagerGroup/ESMWeb/Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput" />
          </toPorts>
        </lBChannel>
        <sFSwitchChannel name="SW:ESMWeb:Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp">
          <toPorts>
            <inPortMoniker name="/EnglishSchoolManager/EnglishSchoolManagerGroup/ESMWeb/Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp" />
          </toPorts>
        </sFSwitchChannel>
      </channels>
      <maps>
        <map name="MapCertificate|ESMWeb:Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" kind="Identity">
          <certificate>
            <certificateMoniker name="/EnglishSchoolManager/EnglishSchoolManagerGroup/ESMWeb/Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" />
          </certificate>
        </map>
        <map name="MapESMWeb:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/EnglishSchoolManager/EnglishSchoolManagerGroup/ESMWeb/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapESMWeb:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountEncryptedPassword" kind="Identity">
          <setting>
            <aCSMoniker name="/EnglishSchoolManager/EnglishSchoolManagerGroup/ESMWeb/Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountEncryptedPassword" />
          </setting>
        </map>
        <map name="MapESMWeb:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountExpiration" kind="Identity">
          <setting>
            <aCSMoniker name="/EnglishSchoolManager/EnglishSchoolManagerGroup/ESMWeb/Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountExpiration" />
          </setting>
        </map>
        <map name="MapESMWeb:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountUsername" kind="Identity">
          <setting>
            <aCSMoniker name="/EnglishSchoolManager/EnglishSchoolManagerGroup/ESMWeb/Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountUsername" />
          </setting>
        </map>
        <map name="MapESMWeb:Microsoft.WindowsAzure.Plugins.RemoteAccess.Enabled" kind="Identity">
          <setting>
            <aCSMoniker name="/EnglishSchoolManager/EnglishSchoolManagerGroup/ESMWeb/Microsoft.WindowsAzure.Plugins.RemoteAccess.Enabled" />
          </setting>
        </map>
        <map name="MapESMWeb:Microsoft.WindowsAzure.Plugins.RemoteForwarder.Enabled" kind="Identity">
          <setting>
            <aCSMoniker name="/EnglishSchoolManager/EnglishSchoolManagerGroup/ESMWeb/Microsoft.WindowsAzure.Plugins.RemoteForwarder.Enabled" />
          </setting>
        </map>
        <map name="MapESMWebInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/EnglishSchoolManager/EnglishSchoolManagerGroup/ESMWebInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="ESMWeb" generation="1" functional="0" release="0" software="C:\Users\Felipe\Documents\Visual Studio 2010\Projects\EnglishSchoolManager\EnglishSchoolManager\csx\Debug\roles\ESMWeb" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="768" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
              <inPort name="Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput" protocol="tcp" />
              <inPort name="Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp" protocol="tcp" portRanges="3389" />
              <outPort name="ESMWeb:Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp" protocol="tcp">
                <outToChannel>
                  <sFSwitchChannelMoniker name="/EnglishSchoolManager/EnglishSchoolManagerGroup/SW:ESMWeb:Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp" />
                </outToChannel>
              </outPort>
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountEncryptedPassword" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountExpiration" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountUsername" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.RemoteAccess.Enabled" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.RemoteForwarder.Enabled" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;ESMWeb&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;ESMWeb&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;e name=&quot;Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp&quot; /&gt;&lt;e name=&quot;Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
            <storedcertificates>
              <storedCertificate name="Stored0Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" certificateStore="My" certificateLocation="System">
                <certificate>
                  <certificateMoniker name="/EnglishSchoolManager/EnglishSchoolManagerGroup/ESMWeb/Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" />
                </certificate>
              </storedCertificate>
            </storedcertificates>
            <certificates>
              <certificate name="Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" />
            </certificates>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/EnglishSchoolManager/EnglishSchoolManagerGroup/ESMWebInstances" />
            <sCSPolicyUpdateDomainMoniker name="/EnglishSchoolManager/EnglishSchoolManagerGroup/ESMWebUpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/EnglishSchoolManager/EnglishSchoolManagerGroup/ESMWebFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyUpdateDomain name="ESMWebUpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyFaultDomain name="ESMWebFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="ESMWebInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="8a6f7ab1-196a-4125-abe3-4f5f16e68e1b" ref="Microsoft.RedDog.Contract\ServiceContract\EnglishSchoolManagerContract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="8c14c86e-9d32-49cd-9595-6ddd18c8b538" ref="Microsoft.RedDog.Contract\Interface\ESMWeb:Endpoint1@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/EnglishSchoolManager/EnglishSchoolManagerGroup/ESMWeb:Endpoint1" />
          </inPort>
        </interfaceReference>
        <interfaceReference Id="86bd5410-bdfe-42b6-b6ce-542dc57c7f2d" ref="Microsoft.RedDog.Contract\Interface\ESMWeb:Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/EnglishSchoolManager/EnglishSchoolManagerGroup/ESMWeb:Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>