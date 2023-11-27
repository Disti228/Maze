import random

player_x, player_y = 0, 0


# field
def draw_field(field, height, width):
    for i in range(height):
        for j in range(width):
            if i == player_y and j == player_x:
                symbol_to_print = '@'
            else:
                symbol_to_print = field[i][j]
            print(symbol_to_print, end='')
        print()


def create_field(height, width, block_freq):
    field = [[]]
    for i in range(height):
        field.append([])
        for j in range(width):
            rand_number = random.randint(0, 100)
            if rand_number < block_freq:
                cell = '#'
            else:
                cell = ' '
            field[i].append(cell)
    return field


def place_character(height, width):
    x = random.randint(0, width - 1)
    y = random.randint(0, height - 1)
    return (x, y)


def is_end_game():
    return False


def get_input():
    dx, dy = 0, 0
    input_string = input()
    if input_string == '':
        return 0, 0

    input_char = input_string[0]
    if input_char == 'w' or input_char == 'W':
        dy = -1
    if input_char == 'a' or input_char == 'A':
        dx = -1
    if input_char == 's' or input_char == 'S':
        dy = +1
    if input_char == 'd' or input_char == 'D':
        dx = +1
    return dx, dy


def is_point_inside_field(x, y, height, width):
    return x >= 0 and y >= 0 and x < width and y < height


def is_walkable(x, y, field):
    if field[y][x] == '#':
        return False

    return True


def can_go_to(x, y, field, height, width):
    if not is_point_inside_field(x, y, height, width):
        return False
    if not is_walkable(x, y, field):
        return False
    return True


def go_to(new_x, new_y):
    global player_x
    global player_y
    player_x, player_y = new_x, new_y


def try_go_to(new_x, new_y, field, height, width):
    if can_go_to(new_x, new_y, field, height, width):
        go_to(new_x, new_y)


def logic(dx, dy, field, height, width):
    try_go_to(player_x + dx, player_y + dy, field, height, width)


def main():
    field_height, field_width = 10, 15
    field = create_field(field_height, field_width, 25)
    player_x, player_y = place_character(field_height, field_width)

    while not is_end_game():
        draw_field(field, field_height, field_width)
        dx, dy = get_input()
        logic(dx, dy, field, field_height, field_width)


main()