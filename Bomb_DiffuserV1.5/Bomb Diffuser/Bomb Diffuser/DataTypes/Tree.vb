Imports System.Collections.Generic
Imports System.ComponentModel

Module MTree
    Public Class MyNode
        Public Name As String
        Public Str As Boolean

        Public Sub New(ByVal new_name As String, ByVal str As Boolean)
            Name = new_name
            str = str
        End Sub

        Public Overrides Function ToString() As String
            Return Name
        End Function
    End Class

    Public Class Tree(Of data_type)
        Private m_Root As TreeNode(Of data_type) = Nothing

        Public Property Root() As TreeNode(Of data_type)
            Get
                Return m_Root
            End Get
            Set(ByVal value As TreeNode(Of data_type))
                m_Root = value
            End Set
        End Property

        Public Sub Clear()
            m_Root = Nothing
        End Sub

        Public Function MakeRoot(ByVal node_item As data_type) As TreeNode(Of data_type)
            m_Root = New TreeNode(Of data_type)(node_item)
            Return m_Root
        End Function

        Public Overrides Function ToString() As String
            Return m_Root.ToString()
        End Function
    End Class

    Public Class TreeNode(Of data_type)
        Public NodeObject As data_type
        Public Children As New List(Of TreeNode(Of data_type))

        Public Sub New(ByVal node_object As data_type)
            NodeObject = node_object
        End Sub

        Public Function AddChild(ByVal node_item As data_type) As TreeNode(Of data_type)
            Dim child_node As New TreeNode(Of data_type)(node_item)

            Children.Add(child_node)

            Return child_node
        End Function

        Public Sub AddChild(ByVal node_item As TreeNode(Of data_type))
            NodeObject = node_item.NodeObject
            Children = node_item.Children
        End Sub

        Public Function getChildCount() As Integer
            Return Children.Count()
        End Function

        Public Shadows Function ToString(Optional ByVal indent As Integer = 0) As String
            Dim txt As String
            txt = New String(" "c, indent) & NodeObject.ToString & vbCrLf

            For Each child As TreeNode(Of data_type) In Children
                txt &= child.ToString(indent + 2)
            Next child

            Return txt
        End Function
    End Class
End Module