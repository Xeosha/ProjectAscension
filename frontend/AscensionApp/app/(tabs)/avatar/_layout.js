import { Drawer } from "expo-router/drawer";
import { MaterialCommunityIcons } from '@expo/vector-icons';
import { View, Pressable, StyleSheet, Text, Image } from 'react-native';
import { COLORS, FONTS } from '../../../constants/constants';

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

  const CustomDrawerContent = (props) => (
    <View style={{ flex: 1 }}>
      {/* Аватар персонажа */}
      <View style={styles.avatarContainer}>
        <MaterialCommunityIcons name="account" size={96} color="#fff" />
        <Text style={styles.avatarName}>Имя персонажа</Text>
      </View>

      {/* Список экранов меню */}
      <View style={{ flex: 1 }}>
        {screens.map(screen => (
          <Pressable 
            key={screen.name}
            onPress={() => props.navigation.navigate(screen.name)}
            style={styles.drawerItem}
          >
            <MaterialCommunityIcons 
              name={screen.icon} 
              size={24} 
              color={COLORS.primary} 
            />
            <Text style={styles.drawerText}>{screen.title}</Text>
          </Pressable>
        ))}
      </View>
    </View>
  );

  return (
    <Drawer
      drawerContent={(props) => <CustomDrawerContent {...props} />}
      screenOptions={{
        drawerStyle: {
          backgroundColor: COLORS.surface,
          width: 300,
        },
        headerStyle: {
          backgroundColor: COLORS.primary,
          borderBottomWidth: 0,
        },
        headerTintColor: "#fff",
        headerRight: () => <HeaderRight />,
      }}
    >
      {screens.map(screen => (
        <Drawer.Screen 
          key={screen.name} 
          name={screen.name} 
          options={{ title: screen.title }} 
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
  avatarContainer: {
    alignItems: 'center',
    paddingVertical: 20,
    backgroundColor: COLORS.primary,
  },
  avatar: {
    width: 80,
    height: 80,
    borderRadius: 40,
    marginBottom: 10,
  },
  avatarName: {
    fontSize: 14,
    color: '#fff',
    fontWeight: 'bold',
    fontFamily: FONTS.regular,
  },
  drawerItem: {
    flexDirection: 'row',
    alignItems: 'center',
    paddingVertical: 10,
    paddingHorizontal: 15,
  },
  drawerText: {
    fontSize: 12,
    marginLeft: 15,
    color: COLORS.white,
    fontFamily: FONTS.regular,
  },
});
