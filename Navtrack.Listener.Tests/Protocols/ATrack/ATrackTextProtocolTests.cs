using Navtrack.Listener.Protocols.ATrack;
using NUnit.Framework;

namespace Navtrack.Listener.Tests.Protocols.ATrack
{
    public class ATrackTextProtocolTests : BaseProtocolTests<ATrackProtocol, ATrackMessageHandler>
    {
        [Test]
        public void DeviceSends1Location_1LocationIsParsed_1()
        {
            ProtocolTester.SendStringFromDevice(
                "@P,93D1,419,0,357766091026083,1557178589,1557178590,1557178590,-121899637,37406241,338,230,2809,8,0,0,0,0,,2000,2000,\r\n");

            Assert.IsNotNull(ProtocolTester.LastParsedLocation);
        }

        [Test]
        public void DeviceSends1Location_1LocationIsParsed_2()
        {
            ProtocolTester.SendStringFromDevice(
                "@P,1126,121,104547,358901048091554,20180412143513,20180412143514,20180413060000,16423389,48178700,108,2,6.5,9,0,0,0,0,0,2000,2000,\r\n");

            Assert.IsNotNull(ProtocolTester.LastParsedLocation);
        }

        [Test]
        public void DeviceSends1Location_1LocationIsParsed_3()
        {
            ProtocolTester.SendStringFromDevice(
                "@P,434E,124,104655,358901048091554,20180412143706,20180412143706,20180413060107,16423389,48178700,108,121,6.5,10,0,0,0,0,0,2000,2000,\r\n");

            Assert.IsNotNull(ProtocolTester.LastParsedLocation);
        }

        [Test]
        public void DeviceSends1Location_1LocationIsParsed_4()
        {
            ProtocolTester.SendStringFromDevice(
                "@P,9493,402,143,356961075931165,1546830150,1546830151,1546830151,-88429209,44271154,54,10,0,10,1,0,0,0,1858AE010000,2000,2000,\u001A,%CI%FL%ML%VN%PD%FC%EL%ET%AT%MF%MV%BV%DT%GN%GV%ME%RL%RP%SA%SM%TR%IA%MP,0,0,2T1KR32E28C706185,0,1,0,7,251,89,118,41,0,00A5001A040800A5001A040B00A5001A040C00A5001A040900A4001C040D00A50019040900A60019040900A4001B040B00A5001A040900A7001A040E\u001A,008CFE7C03C4\u001A,356961075931165,0,0,12,0,18,5,0\r\n");

            Assert.IsNotNull(ProtocolTester.LastParsedLocation);
        }

        [Test]
        public void DeviceSends1Location_1LocationIsParsed_5()
        {
            ProtocolTester.SendStringFromDevice(
                "@P,6254,235,989,356961075931165,1534381563,1534381564,1534381564,-88429188,44271225,70,2,200563,8,1,0,0,0,,2000,2000,,%CI%CE%CN%GQ%GS%FL%ML%VN%PD%FC%EL%ET%CD%AT%MF%MV,0,310260,18,9,0,0,2T1KR32E28C706185,0,0,0,54,8901260881215247759,252,489,123\r\n");

            Assert.IsNotNull(ProtocolTester.LastParsedLocation);
        }

        [Test]
        public void DeviceSends1Location_1LocationIsParsed_6()
        {
            ProtocolTester.SendHexFromDevice(
                "03012C433538312C3135372C342C3335383838373039353933353839342C32303230303430313037353933312C32303230303430313037353933312C32303230303430313037353933312C32373933393534312C2D32363132313934332C3238382C302C3136322C31312C302C302C302C302C2C323030302C323030302C1A2C313537352C302C302C302C3132342C302C31302C302C302C302C302C3132352C302C372C302C0D0A");

            Assert.IsNotNull(ProtocolTester.LastParsedLocation);
        }

        [Test]
        public void DeviceSends3Locations_3LocationsAreParsed()
        {
            ProtocolTester.SendStringFromDevice(
                "@P,27A6,663,707,356961075931165,1534211298,1534211297,1534211437,-88429190,44271135,288,2,200235,8,1,0,0,0,,2000,2000,,%CI%CE%CN%GQ%GS%FL%ML%VN%PD%FC%EL%ET%CD%AT%MF%MV,0,310260,17,9,0,0,2T1KR32E28C706185,0,0,0,80,8901260881215247759,251,59,124\r\n" +
                "1534211353,1534211357,1534211437,-88429190,44271135,288,2,200235,7,1,0,0,0,,2000,2000,,%CI%CE%CN%GQ%GS%FL%ML%VN%PD%FC%EL%ET%CD%AT%MF%MV,0,310260,17,2,0,0,2T1KR32E28C706185,0,0,0,79,8901260881215247759,251,60,124\r\n" +
                "1534211417,1534211417,1534211437,-88429190,44271135,288,2,200235,7,1,0,0,0,,2000,2000,,%CI%CE%CN%GQ%GS%FL%ML%VN%PD%FC%EL%ET%CD%AT%MF%MV,0,310260,17,2,0,0,2T1KR32E28C706185,0,0,0,78,8901260881215247759,251,56,124\r\n");

            Assert.AreEqual(3, ProtocolTester.TotalParsedLocations.Count);
        }

        [Test]
        public void DeviceSends4Locations_4LocationsAreParsed()
        {
            ProtocolTester.SendStringFromDevice(
                "@P,FD34,720,12256,357520076794151,1535445349,1535445354,1535500603,106784149,-6283086,105,2,138,0,3,0,0,0,,2000,2000,,%CI%TR%MV%BV%AT%SA%ET%GQ%GS%PC%RP%OD%AV1%XS%VS,0,0,0,0,0,0,0,0,1011677,0,138,0,0,0\r\n" +
                "1535445376,1535445374,1535500603,106783763,-6282981,105,101,138,6,2,0,0,0,,2000,2000,,%CI%TR%MV%BV%AT%SA%ET%GQ%GS%PC%RP%OD%AV1%XS%VS,0,141,41,60,12,0,0,7,1011677,0,138,0,0,0\r\n" +
                "1535445380,1535445378,1535500603,106783763,-6282981,105,103,138,6,2,0,0,0,,2000,2000,,%CI%TR%MV%BV%AT%SA%ET%GQ%GS%PC%RP%OD%AV1%XS%VS,0,135,41,61,12,0,0,9,1011677,0,138,0,0,0\r\n" +
                "1535445415,1535445415,1535500603,106783763,-6282981,105,2,138,7,2,0,0,0,,2000,2000,,%CI%TR%MV%BV%AT%SA%ET%GQ%GS%PC%RP%OD%AV1%XS%VS,0,135,41,61,12,0,21,10,1011677,0,138,0,0,0\r\n");

            Assert.AreEqual(4, ProtocolTester.TotalParsedLocations.Count);
        }

        [Test]
        public void DeviceSends5Locations_5LocationsAreParsed()
        {
            ProtocolTester.SendStringFromDevice(
                "@P,0EBB,687,1917,357298070426498,1534718280,1534718279,1534739774,-88643875,44210148,270,2,57128,6,1,130,0,0,,2000,2000,,%CI%GQ%GS%CN%CE%MV%SA,5,10,310260,7888593,137,16\r\n" +
                "1534718283,1534718283,1534739774,-88645243,44210145,269,2,57129,6,1,129,0,0,,2000,2000,,%CI%GQ%GS%CN%CE%MV%SA,5,10,310260,7888593,137,16\r\n" +
                "1534718286,1534718285,1534739774,-88646581,44210136,269,2,57130,6,1,127,0,0,,2000,2000,,%CI%GQ%GS%CN%CE%MV%SA,99,10,0,0,137,16\r\n" +
                "1534718289,1534718288,1534739774,-88647911,44210123,269,2,57131,6,1,127,0,0,,2000,2000,,%CI%GQ%GS%CN%CE%MV%SA,99,10,0,0,137,16\r\n" +
                "1534718292,1534718291,1534739774,-88649229,44210111,269,2,57132,6,1,124,0,0,,2000,2000,,%CI%GQ%GS%CN%CE%MV%SA,99,10,0,0,136,16\r\n");

            Assert.AreEqual(5, ProtocolTester.TotalParsedLocations.Count);
        }
    }
}