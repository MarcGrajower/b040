Imports System

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports b040



'''<summary>
'''This is a test class for bzBestelTest and is intended
'''to contain all bzBestelTest Unit Tests
'''</summary>
<TestClass()> _
Public Class bzBestelTest


    Private testContextInstance As TestContext

    '''<summary>
    '''Gets or sets the test context which provides
    '''information about and functionality for the current test run.
    '''</summary>
    Public Property TestContext() As TestContext
        Get
            Return testContextInstance
        End Get
        Set(ByVal value As TestContext)
            testContextInstance = Value
        End Set
    End Property

#Region "Additional test attributes"
    '
    'You can use the following additional attributes as you write your tests:
    '
    'Use ClassInitialize to run code before running the first test in the class
    '<ClassInitialize()>  _
    'Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)
    'End Sub
    '
    'Use ClassCleanup to run code after all tests in a class have run
    '<ClassCleanup()>  _
    'Public Shared Sub MyClassCleanup()
    'End Sub
    '
    'Use TestInitialize to run code before running each test
    '<TestInitialize()>  _
    'Public Sub MyTestInitialize()
    'End Sub
    '
    'Use TestCleanup to run code after each test has run
    '<TestCleanup()>  _
    'Public Sub MyTestCleanup()
    'End Sub
    '
#End Region


    '''<summary>
    '''A test for lExistsBestelling
    '''</summary>
    <TestMethod()> _
    Public Sub lExistsBestellingTest()
        Dim target As bzBestel = New bzBestel ' TODO: Initialize to an appropriate value
        Dim nKlant As Long = 0 ' TODO: Initialize to an appropriate value
        Dim dBest As DateTime = New DateTime ' TODO: Initialize to an appropriate value
        Dim dLevering As DateTime = New DateTime ' TODO: Initialize to an appropriate value
        Dim expected As Boolean = False ' TODO: Initialize to an appropriate value
        Dim actual As Boolean
        actual = target.lExistsBestelling(nKlant, dLevering)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub
End Class
