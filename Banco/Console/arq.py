import math;


a = int(input("digite o valor de a"))

b = int(input("digite o valor de b"))

erro = 0.05

xk = a+b/2

def funcao(x):
    return math.e**(-x)-math.sin(x)


## criterio de parada

if f(b) * f(a) < 0: # pois um é positivo e o outro negativo 
    while(math.fabs(b-a)/xk>erro):
        xk = (a+b)/2/2
        if  f(xk) ==0:
            break
else:
    print("a raiz é " + round(xk,5) )











