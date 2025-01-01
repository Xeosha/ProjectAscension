import { Drawer } from "expo-router/drawer";
import { MaterialCommunityIcons } from '@expo/vector-icons';
import { View, Pressable, StyleSheet } from 'react-native';

export default function AvatarLayout() {
  const HeaderRight = () => (
    <View style={styles.headerButtons}>
      <Pressable 
        style={styles.headerButton}
        onPress={() => console.log('Customize pressed')}
      >
        <MaterialCommunityIcons name="pencil" size={24} color="#fff" />
      </Pressable>
      
      <Pressable 
        style={styles.headerButton}
        onPress={() => console.log('Notifications pressed')}
      >
        <MaterialCommunityIcons name="bell" size={24} color="#fff" />
      </Pressable>
    </View>
  );

  // Список экранов
  const screens = [
    { name: "index", title: "Герои", icon: "home" },
    { name: "health", title: "Здоровье", icon: "heart" },
    { name: "achievements", title: "Достижения", icon: "trophy" },
    { name: "settings", title: "Настройки", icon: "cog" },
    { name: "support", title: "Поддержка", icon: "help-circle" },
    { name: "language", title: "Настройки языка", icon: "translate" },
    { name: "logout", title: "Выйти из аккаунта", icon: "logout" },
  ];

  return (
    <Drawer
      screenOptions={{
        drawerStyle: {
          backgroundColor: "#f8f9fa",
          width: 240,
        },
        headerStyle: {
          backgroundColor: "#4a90e2",
        },
        headerTintColor: "#fff",
        headerRight: () => <HeaderRight />,
      }}
    >
      {screens.map(screen => (
        <Drawer.Screen 
          key={screen.name} // Уникальный ключ для каждого экрана
          name={screen.name} 
          options={{ 
            title: screen.title,
            drawerIcon: ({ color, size }) => (
              <MaterialCommunityIcons name={screen.icon} size={size} color={color} />
            ),
          }}
        />
      ))}
    </Drawer>
  );
}

const styles = StyleSheet.create({
  headerButtons: {
    flexDirection: 'row',
    marginRight: 10,
  },
  headerButton: {
    marginHorizontal: 8,
    padding: 4,
  },
});
