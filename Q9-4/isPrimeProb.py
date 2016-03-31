from random import randint
import math

r = 100000
n = 64

print 1 / 2

def is_prime(n):
    if n % 2 == 0 and n > 2: 
        return False
    return all(n % i for i in range(3, int(math.sqrt(n)) + 1, 2))

count = 0
for i in range(r):
    # random number
    prime = randint(0, math.pow(2, n))
    if is_prime(prime):
        count += 1

print 'Count: '
print count
print '\n'

print 'Range: '
print r
print '\n'

print 'Probability: '
print count / r
print '\n'

