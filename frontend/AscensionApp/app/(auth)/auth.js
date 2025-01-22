import { View, Text, StyleSheet, Linking, TouchableOpacity } from 'react-native';

export default function AuthScreen() {
  return (
    <View style={styles.container}>
      <Text style={styles.title}>
        Mobile Version
      </Text>
      <Text style={styles.description}>
        Please use our web version in Telegram Mini Apps
      </Text>
      <TouchableOpacity
        style={styles.button}
        onPress={() => Linking.openURL('https://t.me/your_bot')}
      >
        <Text style={styles.buttonText}>Open in Telegram</Text>
      </TouchableOpacity>
    </View>
  );
}

const styles = StyleSheet.create({
    container: {
      flex: 1,
      justifyContent: 'center',
      alignItems: 'center',
      padding: 20,
    },
    title: {
      fontSize: 24,
      fontWeight: 'bold',
      marginBottom: 10,
      textAlign: 'center',
    },
    description: {
      fontSize: 16,
      color: '#666',
      textAlign: 'center',
      marginBottom: 20,
    },
    button: {
      backgroundColor: '#0088cc',
      paddingHorizontal: 20,
      paddingVertical: 10,
      borderRadius: 8,
    },
    buttonText: {
      color: '#fff',
      fontSize: 16,
      fontWeight: 'bold',
    },
    error: {
      color: 'red',
      marginTop: 10,
      textAlign: 'center',
    },
  });