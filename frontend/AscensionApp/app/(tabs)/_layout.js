import { Tabs } from "expo-router";
import { MaterialCommunityIcons } from '@expo/vector-icons';

export default function Layout() {
  return (
    <Tabs 
      initialRouteName="avatar"
      screenOptions={{
        headerShown: false // Скрываем заголовок для всех табов
      }}
    >
      <Tabs.Screen
        name="avatar"
        options={{
          title: "Аватар",
          tabBarIcon: ({ color, size }) => (
            <MaterialCommunityIcons name="account" size={size} color={color} />
          ),
        }}
      />
      <Tabs.Screen
        name="map"
        options={{
          title: "Карта",
          tabBarIcon: ({ color, size }) => (
            <MaterialCommunityIcons name="map" size={size} color={color} />
          ),
        }}
      />
      <Tabs.Screen
        name="tower"
        options={{
          title: "Башня",
          tabBarIcon: ({ color, size }) => (
            <MaterialCommunityIcons name="castle" size={size} color={color} />
          ),
        }}
      />
      <Tabs.Screen
        name="shop"
        options={{
          title: "Магазин",
          tabBarIcon: ({ color, size }) => (
            <MaterialCommunityIcons name="store" size={size} color={color} />
          ),
        }}
      />
      <Tabs.Screen
        name="guild"
        options={{
          title: "Гильдия",
          tabBarIcon: ({ color, size }) => (
            <MaterialCommunityIcons name="shield-crown" size={size} color={color} />
          ),
        }}
      />
    </Tabs>
  );
}