# ImageToWB
A program what allows to convert a color image into a white and black image

The program was created on WPF. There are 3 algorithms for converting image:
1. ArithmeticAverage - it calculate the arithmetic average for three channels and set this value to each channel.
2. Coefficients - it use three coefficients for calculating a new value for each channel. Formula: NewValue = R * R_Coefficient + G * G_Coefficient + B * B_Coefficient.
3. OnlyBWConvertion - it use a variable with the name **level** for calculating a new color. Each channels' value should be greater than the **level** value, if this is true, then the color is white, else the color is black.
