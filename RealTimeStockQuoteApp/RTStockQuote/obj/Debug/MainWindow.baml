   M S B A M L   `   `   `  ����  RTStockQuote    RTStockQuote.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6F   -   5          � Title$-  'Real Time Stock Quote Price Application��5   	   $	��395��69   $	��535��6F    � WindowStyle$
 None=�6R    � 
ResizeMode$ NoResize=�6e   .��5      � 
���   � � ColumnDefinitions 5   
   �� 5      $	��533 �6    � RowDefinitions 5
   
   �� 5      $	��395 �6   .+�5   
   �� -   5         ��Name$ 
btn_Remove��5      $��_Remove��6%   $��Center=�68   $��444,80,23,285q�6U   $��66��6l   
���   ����	#00000000��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ Black��6#   	 � Offset$	 0Q�61   � 5      $ White��6#   $	 1Q�61   5      5      �� 5   
   -   5        $ btn_Add��5      $
��_Add��6"   $��Center=�61   $��354,80,109,285q�6N   $��70��6f   ���	#00000000��5      �� 5      $ 0.5,1&�6&   $ 0.5,0&�67   .��5      � $ Black��6#   $	 0Q�61   � 5      $ White��6#   $	 1Q�61   5      5      �� 5   
   -   5        
 ��Name$
 txt_StockQuote��5      $
��Left=�6*    �� TextWrapping$
 Wrap=�6E   $��Spy,qqqq,goog��6Y   $	��303��6n   $��12,80,0,285q�6z   ���	#FFB0B0B0���	#FF471515$��Trebuchet MS)�6�   $��14(�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dg_StockList��5         AutoGenerateColumns .  $
��Left=�6F   $��	15,0,0,45q�6a   $��Bottom=�6t    J� RenderTransformOrigin$ 	0.5,1.154&�6�   $	��215��6�   $	��508��6�   ���	#FF6C6964   Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn   Header$ Quote��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6N   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *Quote+6Z     5"      $ Price��6%   $ * 6N    64   �� *Price+6Z     5#      $ 
Pcls Price��6%   $ * 6W    69   �� *	PclsPrice+6c     5$      $
 Time��6%   $ * 6L    63   �� *Time+6X   5&      �� 5'   
   -   5        $ btn_Quit��5'      $��_Quit��6#   $
��Left=�63   $��444,365,0,10q�6N   $��75��6d   $ 
1.067,1.65&�6o   ��5(      �� 5)      $ 0.5,1&�6&   $ 0.5,0&�67   .��5*      � $ Black��6#   $	 0Q�61   � 5+      $ White��6#   $	 1Q�61   5,      ��5.      �� 5/      $ 0.5,1&�6&   $ 0.5,0&�67   .��50      � $ Black��6#   $	 0Q�61   � 51      $ Black��6#   $	 1Q�61   52      54      �� 55   
   $'��!Real Time Stock Quote Application��6   $
��Left=�6<   $��	60,15,0,0q�6W   $	��Top=�6j   $	��425��6�   $��SimSun)�6�   $��24(�6�   $
��Bold"�6�   $��45��6�   ���	#00000000��56      �� 57      $ 0.5,1&�6&    � MappingMode$ RelativeToBoundingBox=�67   $ 0.5,0&�6[   .��58      � $ Black��6#   $	 0Q�61   � 59      $ White��6#   $	 1Q�61   5:      5<      5?      5@      