import { useEffect, useState } from 'react';
import { View, Text, TouchableOpacity, StyleSheet } from 'react-native';

export default function AuthScreen() {
  const [error, setError] = useState('');
  const [isTelegramAvailable, setIsTelegramAvailable] = useState(false);

  console.log(window)
  console.log(window.Telegram + "1")

  useEffect(() => {
    
    if (window.Telegram?.WebApp) {
      setIsTelegramAvailable(true);
      
      // Если пользователь уже авторизован в Telegram
      const { initData, initDataUnsafe } = window.Telegram.WebApp;
      if (initDataUnsafe?.user) {
        handleTelegramLogin(initData);
      }
    }
  }, []);

  useEffect(() => {
    const intervalId = setInterval(() => {
      if (window.Telegram?.WebApp) {
        setIsTelegramAvailable(true);
        clearInterval(intervalId);  
        // Если пользователь уже авторизован в Telegram
        const { initData, initDataUnsafe } = window.Telegram.WebApp;
        if (initDataUnsafe?.user) {
          handleTelegramLogin(initData);
        }
      }

      return () => clearInterval(intervalId);
    }, 100); // Проверять каждые 100 мс

    return () => clearInterval(intervalId); // Очистить интервал при размонтировании
}, []);

  const handleTelegramLogin = async (initData) => {
    try {
      //router.replace('/(app)');
    } catch (err) {
      setError(err.message);
    }
  };

  if (!isTelegramAvailable) {
    return (
      <View style={styles.container}>
        <Text style={styles.title}>
          Please open this app in Telegram
        </Text>
        <Text style={styles.description}>
          This app is designed to work within Telegram Mini Apps
        </Text>
        <TouchableOpacity 
          style={styles.button}
          onPress={() => window.open('https://t.me/your_bot', '_blank')}
        >
          <Text style={styles.buttonText}>Open in Telegram</Text>
        </TouchableOpacity>
      </View>
    );
  }

  return (
    <View style={styles.container}>
      <Text style={styles.title}>Loading...</Text>
      {error && <Text style={styles.error}>{error}</Text>}
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