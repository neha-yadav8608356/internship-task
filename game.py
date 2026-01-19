import random

def game():
    number = random.randint(1, 100)
    # Difficulty Level
    level = input("Choose difficulty 'easy' or 'hard': ")
    attempts = 10 if level == 'easy' else 5
    score = 100

    while attempts > 0:
        print(f"You have {attempts} attempts left.")
        guess = int(input("Make a guess: "))
        
        if guess == number:
            print(f"Correct! Your final score is: {score}")
            return
        elif guess > number:
            print("Too high!")
        else:
            print("Too low!")
        
        attempts -= 1
        score -= 10 # Score tracking

    print(f"Game Over! The number was {number}.")

game()