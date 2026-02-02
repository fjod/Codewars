package main

import (
	"fmt"
	"math/rand"
	"time"
)

type IProducer interface {
	Generate(chan string)
}

type IConsumer interface {
	Consume(string)
}

type PubSub struct {
	channel   chan string
	producers []IProducer
	consumers []IConsumer
	exit      chan struct{}
}

func NewPubSub() *PubSub {
	ret := &PubSub{
		make(chan string, 100),
		make([]IProducer, 0),
		make([]IConsumer, 0),
		make(chan struct{}),
	}
	// producer ticker: periodically ask producers to generate
	go func() {
		ticker := time.NewTicker(time.Second)
		defer ticker.Stop()
		for {
			select {
			case <-ticker.C:
				for _, producer := range ret.producers {
					go producer.Generate(ret.channel)
				}
			case <-ret.exit:
				return
			}
		}
	}()
	// consumer loop: fan out each message to all consumers
	go func() {
		for msg := range ret.channel {
			for _, consumer := range ret.consumers { // fans out each one to every consumer
				consumer.Consume(msg)
			}
		}
	}()
	return ret
}

func (p *PubSub) Close() {
	p.exit <- struct{}{}
	close(p.channel)
}

func (p *PubSub) AddProducer(producer IProducer) {
	p.producers = append(p.producers, producer)
}

func (p *PubSub) AddConsumer(consumer IConsumer) {
	p.consumers = append(p.consumers, consumer)
}

type Consumer struct {
	name string
}

func NewConsumer(name string) *Consumer {
	return &Consumer{name}
}
func (c *Consumer) Consume(msg string) {
	fmt.Printf("consume %s | name %v at time %v\n", msg, c.name, time.Now())
}

type Producer struct {
	name string
}

func NewProducer(name string) *Producer {
	return &Producer{name}
}
func (p *Producer) Generate(channel chan string) {
	r := rand.Intn(100)
	if r < 50 {
		return
	}
	if r < 90 {
		channel <- fmt.Sprintf("producer %v generated number %v", p.name, r)
	}
	time.Sleep(time.Duration(r) * time.Millisecond * 100)
	channel <- fmt.Sprintf("producer %v slept and generated number %v", p.name, r)
}
func main() {
	pub := NewPubSub()
	for i := 0; i < 10; i++ {
		producer := NewProducer(fmt.Sprintf("producer %v", i))
		pub.AddProducer(producer)
		if i%2 == 0 {
			consumer := NewConsumer(fmt.Sprintf("consumer %v", i))
			pub.AddConsumer(consumer)
		}
	}
	time.Sleep(time.Second * 20)
	pub.Close()
}
