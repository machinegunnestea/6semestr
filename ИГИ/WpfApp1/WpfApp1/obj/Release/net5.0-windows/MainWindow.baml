   M S B A M L   `   `   `  ����   UI    UI.MainWindow   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       � Title$  
MainWindow��$	��450��$	��800��.���  � RowDefinitions �� $��* ��� $��50 �.+��� $��0�� �� SelectedItem �� *SelectedTabItem+.@��� -   $��MovieTab������ $��Movie�� � ContextMenu �� .@�m� $��Удалить�� m� Command �� *
DeleteItem+.���� -    ��Name$ ViewAllMovies������ *
AllMovie+ �� *SelectedMovie+ �� View �� .P��� $��Title�� �� DisplayMemberBinding ��  �� Path$ Title��� $
��Cost�� �� $
 Cost��� $
��Type�� �� $ MovieTypeTitle��� -   $��UsersTab������ $
��User�� �� .@�m� $��Удалить�� �� *
DeleteItem+.���� -   $ ViewAllUsers������ *	AllUser+ �� *SelectedUser+ �� .P��� $��Login�� �� $ Login��� $��Password�� �� $ Password��� $
��Role�� �� $
 Role��� -   $��MovieTypeTab������ $
��Type�� �� .@�m� $��Удалить�� �� *
DeleteItem+.���� -   $ ViewAllMovieTypes������ *AllMovieType+ �� *SelectedMovieType+ �� .P��� $��Title�� �� $ Title��� $��1��	 �� Orientation$	 
Horizontal=�$��Right=�.+��� $��	New Movie������ *AddNewMovieWnd+�� $��
Find Movie������ *FindMovieWnd+�� $��New MovieType������ *AddNewMovieTypeWnd+�� $��New User������ *AddNewUserWnd+�� $��	Find User������ *FindUserWnd+