   M S B A M L   `   `   `  ����F  BBITServices, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:BITServicesBITServices  5   	   I)clr-namespace:BITServices.UI.UserControlsBITServices.UI.UserControls  5   	       BITServices.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^SharpVectors.Converters.Wpf, Version=1.5.0.0, Culture=neutral, PublicKeyToken=b532964b8548be771svgc&http://sharpvectors.codeplex.com/svgc/  5   	   %localclr-namespace:BITServices  5   	   2uc)clr-namespace:BITServices.UI.UserControls  5   	     � Title$$  BIT Services Management System��5
   	   $	��685��60   $	��800��6=   $	��590��6I   $	��770��6Y    � Icon$ Images/Logo/LogoSmall.png��6h    � 	Resources 5         VisibleIfTrueConverter��%   &	        �� 5   
   6'   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��4* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��8* �6   .+�5   
   � -   5         �Name$ Header��5      $��0��6   $��2��6,   ���#ffbb8a 5      �� 5      $��5* �6#   �� 5      $��* �6#   .+�5      �� $
��Left=�6J   $	��0,5q�6e   ��6   /  )SharpVectors.Converters.SvgImageExtension  */UI/Images/Logo/FullLogo.svg+6e   �� 5      -   5         ��Name$ txbWelcomeMessage��5      $��Center=�6�   $��Right=�6�   $��Italic$�6�   $��16(�6�   ��63   �� *WelcomeMessage+ �� FallbackValue$. (IF YOU CAN READ THIS, THE BINDING FAILED�� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5       -   5        	 ��Name$	 chkAccountDetails��5    >   $��50��6   $��1��6"   $��50��62   $��Center=�6Y   $��Right=�6t   $��0,0,50,0q�6�   $y�Hidden=�6�   ��5!      �� 5"      
 �� 
TargetType"
 ��6&   .R�5#      � .+�5$      A�  A�Name$ 
CheckShape��6&   $��50��6:   $��50��6E   $��1��6Q   
���������5%   "   �� 5&   &    �� ImageSource 61   �� *
ProfilePic+$ PropertyChanged=�5(      5)      5*      5,      5.      ]� 5/   
   -   5         ]�Name$ 
stkSidebar��5/   F   $��1��6   $��0��6!   ���#ffecde��. {�.  .+�50      	� -   5        $��radCoordinator��50   0   $��Coordinator��6     menuRadioButton#��[ 6F   $	��Top=�6o   {�.  6�   	� 51      -   5        $��radContractor��51   /   $��
Contractor��6   #��[ 6D   $	��Top=�6m   6�   	� 52      -   5        $��	radClient��52   +   $��Client��6   #��[ 6<   $	��Top=�6e   6z   	� 53      -   5        $��radJobs��53   (   $	��Job��6   #��[ 67   $	��Top=�6`   6u   �� 54      
�������$��1��6&   $	��Top=�6:   55       � 57   
   -	   5          �Name$ MainContent��57      $��1��6%   $��1��65     � NavigationUIVisibility$ Hidden=�6B   $��5q�6b   
�������$��0,1,0,0q�6�   ���	#FFF9F6F36�   �� 59   
   -
   5         ��Name$ stkProfileDropdown��59     $��1��6   $��1��6"     dropDownBoxAnimate#��[ 62   $��Right=�6^   $	��150��6z   $��0,0,10,0q�6�   y�6�   ��  �� ElementName$ chkAccountDetails�� �� Path$ 	IsChecked� �� 	Converter# [  .+�5:      �� -   5         ��Name$ 
btnProfile��5:      $��Account��6)     accountButtons#��[ 6;   �� 5;      -   5        $ 	btnLogOut��5;      $��Log Out��6(   #��[ 6:   6b   5<      5=      5>      