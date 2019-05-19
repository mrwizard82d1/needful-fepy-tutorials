import base64

original_string = "Hello_World"
print "Original string {original_string}.".format(original_string=original_string)

encoded_string = base64.b64encode(original_string)
print "Encoded string {encoded_string}.".format(encoded_string=encoded_string)

decoded_string = base64.b64decode(encoded_string)
print "Decoded string {decoded_string}.".format(decoded_string=decoded_string)
