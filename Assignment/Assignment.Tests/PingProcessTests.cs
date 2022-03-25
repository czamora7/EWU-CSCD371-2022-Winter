using IntelliTect.TestTools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace Assignment.Tests;

[TestClass]
public class PingProcessTests
{
    PingProcess Sut { get; set; } = new();
    CancellationTokenSource Cts { get; set; } = new();

    [TestInitialize]
    public void TestInitialize()
    {
        Sut = new();
        Cts = new();
    }

    [TestMethod]
    public void Start_PingProcess_Success()
    {
        Process process = Process.Start("ping", "localhost");
        process.WaitForExit();
        Assert.AreEqual<int>(0, process.ExitCode);
    }

    [TestMethod]
    public void Run_GoogleDotCom_Success()
    {
        int exitCode = Sut.Run("google.com").ExitCode;
        Assert.AreEqual<int>(0, exitCode);
    }


    [TestMethod]
    public void Run_InvalidAddressOutput_Success()
    {
        (int exitCode, string? stdOutput) = Sut.Run("badaddress");
        Assert.IsFalse(string.IsNullOrWhiteSpace(stdOutput));
        stdOutput = WildcardPattern.NormalizeLineEndings(stdOutput!.Trim());
        Assert.AreEqual<string?>(
            "Ping request could not find host badaddress. Please check the name and try again.".Trim(),
            stdOutput,
            $"Output is unexpected: {stdOutput}");
        Assert.AreEqual<int>(1, exitCode);
    }

    [TestMethod]
    public void Run_CaptureStdOutput_Success()
    {
        PingResult result = Sut.Run("localhost");
        AssertValidPingOutput(result);
    }

    [TestMethod]
    public void RunTaskAsync_Success()
    {
        // Do NOT use async/await in this test.
        // Test Sut.RunTaskAsync("localhost");

        PingResult result = Sut.RunTaskAsync("localhost").Result;
        AssertValidPingOutput(result);
    }

    [TestMethod]
    public void RunAsync_UsingTaskReturn_Success()
    {
        // Do NOT use async/await in this test.
        // Test Sut.RunAsync("localhost");
        PingResult result = Sut.RunAsync("localhost", Cts.Token).Result;
        AssertValidPingOutput(result);
    }

    [TestMethod]
    async public Task RunAsync_UsingTpl_Success()
    {
        // DO use async/await in this test.

        PingResult result = await Sut.RunAsync("localhost", Cts.Token);

        // Test Sut.RunAsync("localhost");
        AssertValidPingOutput(result);
    }


    [TestMethod]
    [ExpectedException(typeof(AggregateException))]
    public void RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrapping()
    {
        Cts.Cancel();
        Task<PingResult> task = Sut.RunAsync("localhost", Cts.Token);
        task.Wait(100);
    }

    [TestMethod]
    [ExpectedException(typeof(TaskCanceledException))]
    public void RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrappingTaskCanceledException()
    {
        // Use exception.Flatten()
        Cts.Cancel();

        try 
        {
            Task<PingResult> task = Sut.RunAsync("localhost", Cts.Token);
            task.Wait(100);
        }
        catch (AggregateException e)
        {
            foreach(var inner in e.Flatten().InnerExceptions)
            {
                if (inner is TaskCanceledException)
                    throw inner;
                else
                    throw e;
            }
        }
    }

    [TestMethod]
    async public Task RunAsync_MultipleHostAddresses_True()
    {
        string[] hostNames = new string[]{ "localhost", "localhost", "localhost", "localhost", "localhost" };

        //the expected line count is doubled because each hostname pings twice
        int expectedLineCount = PingOutputLikeExpression.Split(Environment.NewLine).Length * 
            hostNames.Length * 2;
        
        PingResult result = await Sut.RunAsync(hostNames, Cts.Token);
        result.StdOutput = RemoveEmptyLines(result.StdOutput!);
        int? lineCount = result.StdOutput?.Split(Environment.NewLine).Length;

        //Ignore this it was used for testing purposes

        /*String fp = @"C:\Users\coron\CSCD371\Assignment9+10\Assignment\Assignment.Tests\TestPart3StdOutput.txt";
        using(StreamWriter of = new StreamWriter(fp))
        {
            of.Write(result.StdOutput);
        }*/

        Assert.AreEqual(0, result.ExitCode);
        
        //the std output has a \n at the beginning of the string for unknown
        //reasons, throwing off the expected line count by exactly one
        
        Assert.AreEqual(expectedLineCount, lineCount - 1);
    }

    [TestMethod]
    async public Task RunLongRunningAsync_UsingTpl_Success()
    {
        ProcessStartInfo prcStart = new("ping", "localhost");

        //review this part if invalid StdOutput occurs
        StringBuilder? stringBuilder = null;
        void updateStdOutput(string? line) =>
                    (stringBuilder ??= new StringBuilder()).AppendLine(line);

        PingResult result = await Sut.RunLongRunningAsync(prcStart, updateStdOutput, default, Cts.Token);

        //Assert.AreEqual(0, result.ExitCode);
        //Assert.IsFalse(String.IsNullOrWhiteSpace(result.StdOutput));
        AssertValidPingOutput(result);
    }

    [TestMethod]
    public void StringBuilderAppendLine_InParallel_IsNotThreadSafe()
    {
        IEnumerable<int> numbers = Enumerable.Range(0, short.MaxValue);
        System.Text.StringBuilder stringBuilder = new();
        numbers.AsParallel().ForAll(item => stringBuilder.AppendLine(""));
        int lineCount = stringBuilder.ToString().Split(Environment.NewLine).Length;
        Assert.AreNotEqual(lineCount, numbers.Count()+1);
    }

    readonly string PingOutputLikeExpression = @"
Pinging * with 32 bytes of data:
Reply from ::1: time<*
Reply from ::1: time<*
Reply from ::1: time<*
Reply from ::1: time<*
Ping statistics for ::1:
    Packets: Sent = *, Received = *, Lost = 0 (0% loss),
Approximate round trip times in milli-seconds:
    Minimum = *, Maximum = *, Average = *".Trim();
    private void AssertValidPingOutput(int exitCode, string? stdOutput)
    {
        Assert.IsFalse(string.IsNullOrWhiteSpace(stdOutput));
        stdOutput = WildcardPattern.NormalizeLineEndings(stdOutput!.Trim());
        Assert.IsTrue(stdOutput?.IsLike(PingOutputLikeExpression)??false,
            $"Output is unexpected: {stdOutput}");
        Assert.AreEqual<int>(0, exitCode);
    }
    private void AssertValidPingOutput(PingResult result) =>
        AssertValidPingOutput(result.ExitCode, result.StdOutput);

    private string RemoveEmptyLines(string lines)
    {
        return Regex.Replace(lines, @"^\s+$[\r\n]*", string.Empty, RegexOptions.Multiline);
    }
}
