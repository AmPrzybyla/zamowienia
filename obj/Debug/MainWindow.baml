   M S B A M L   `   `   `  ����E  Azamowienia, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:zamowienia
zamowienia  5   	       zamowienia.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:zamowienia     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      ]� .+�5
   
   �� $
��Left=�6   $	��200��6+   $��5q�67   .+�5      �� -   5        .��5   3   Dodaj zamówienie6E   �� 5      -   5         ��Name$ ListOfSendedOrders��5      ��5      �� 5      .R�5      � .+�5      �� ��6(   ��  �� Path$ Company��� 5      ��6(   �� $
 Date�5      5      5      5      �� 5   
   $��Bottom=�6   .+�5      � $��Center=�6   .+�5      �� -   5         ��Name$ 
CompanyBox��5      $	��100��6.   �� 5      -   5        $ 
AddressBox��5      $	��200��6.   .��6:   mail6@   �� 5      -   5         ��Name$ 
SendButton��5      $	��120��6-   .��6R   
Send Order6^   5      &   System.Windows.Controls.DataGrid  5      -   5          Name$ TableOfProducts��5         AutoGenerateColumns .     
IsReadOnly 6L   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Nazwa��6)   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 68   �� $ NameOfProduct�  5       $	 Index��6)   
 68   �� $ IndexOfProduct�  5!      $	 Ilość��6)   
 68   �� $ QuantityOfProduct�  5"      $	 Cena/szt��6)   
 6;   �� $ PriceOfProduct�5%      5&      5'      5(      