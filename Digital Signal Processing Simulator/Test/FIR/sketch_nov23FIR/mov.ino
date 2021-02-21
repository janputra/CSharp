float[] input=input[4];
/////////////moving average///////////
input[i]=pembacaan sudut;
if (i>3){
  
  i=2;
  input[2]=input[3];
  input[1]=input[2];
  input[0]=input[1];
 
}

float movAvg=(input[0]+input[1]+input[2]+input[3])/4
i++;
/////////////////////////////////////////

