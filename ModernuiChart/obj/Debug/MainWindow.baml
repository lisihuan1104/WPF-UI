   M S B A M L   `   `   `  ����H  DModernuiChart, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ModernuiChartModernuiChart  5   	   ` \De.TorstenMandelkow.MetroChart, Version=0.9.5818.20693, Culture=neutral, PublicKeyToken=nullwTclr-namespace:De.TorstenMandelkow.MetroChart;assembly=De.TorstenMandelkow.MetroChartDe.TorstenMandelkow.MetroChart 5   	       ModernuiChart.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:ModernuiChart     5   	   k
MetroChartTclr-namespace:De.TorstenMandelkow.MetroChart;assembly=De.TorstenMandelkow.MetroChart     5   	   6chart$using:De.TorstenMandelkow.MetroChart     5	   	     � Title$  Chart��5
      $	��450��6   $	��800��6#    � WindowState$ 	Maximized=�6/   .��5      � -   5        $
��grid��5       � RowDefinitions 5   
   �� 5      $��* �6   6)   �� 5      $��* �6   6)    � ColumnDefinitions 5   
   �� 5      $��* �6   6+   �� 5      $��* �6   6+   �� 5      $��* �6   6+   .+�5   
   6  0De.TorstenMandelkow.MetroChart.ClusteredBarChart  $��0��6'   $��0��64   .  (De.TorstenMandelkow.MetroChart.ChartBase   ChartSubTitle$ Population in millions��6D      
ChartTitle$ Countries by population��5         Series 5      0  *De.TorstenMandelkow.MetroChart.ChartSeries     DisplayMember$
 Name��6)      SeriesTitle$ World largest populations��5      	   ValueMember$	 Count��5      ��5      �� 
 �� Path$
 Populations�5      5      9  3De.TorstenMandelkow.MetroChart.ClusteredColumnChart  5   
   $��0��6*   $��1��67   $ Population in millions��6G   $ Countries by population��5        5"        $
 Name��6)   $ World largest populations��5$      $	 Count��5%      ��5#      �� $
 Populations�5%      5'      2  ,De.TorstenMandelkow.MetroChart.DoughnutChart  5(   
   $��0��6#   $��2��60   $ Population in millions��6@   $ Countries by population��5)       5+        $
 Name��6)   $ World largest populations��5-      $	 Count��5.      ��5,      �� $
 Populations�5.      50      -  'De.TorstenMandelkow.MetroChart.PieChart  51   
   $��1��6   $��0��6+   $ Population in millions��6;   $ Countries by population��52       54        $
 Name��6)   $ World largest populations��56      $	 Count��57      ��55      �� $
 Populations�57      59      4  .De.TorstenMandelkow.MetroChart.StackedBarChart  5:   
   $��1��6%   $��1��62   $ Population in millions��6B   $ Countries by population��5;       5=        $
 Name��6)   $ World largest populations��5?      $	 Count��5@      ��5>      �� $
 Populations�5@      5B      7  1De.TorstenMandelkow.MetroChart.StackedColumnChart  5C   
   $��1��6(   $��2��65   $ Population in millions��6E   $ Countries by population��5D       5F        $
 Name��6)   $ World largest populations��5H      $	 Count��5I      ��5G      �� $
 Populations�5I      5K      5L      5M      